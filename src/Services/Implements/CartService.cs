using Api_Taller.src.DTOs.Cart;
using Api_Taller.src.Mappers;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Services.Interfaces;
using Newtonsoft.Json;
namespace Api_Taller.src.Services.Implements
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        public async Task AddItemCart(CartItemDto cartItemDto, int? userId)
        {
            if (userId == null){
                await AddCartItemCookies(cartItemDto);
            }
            else {
                var cart = await _cartRepository.GetCartByUserId(userId.Value);
                if (cart == null)
                {
                    var user = await _userRepository.GetUserById(userId.Value);
                    if (user == null)
                    {
                        throw new Exception("Usuario no existe");
                    }
                    else {
                        cart = new Cart
                        {
                            UserId = userId.Value,
                            User = user
                        };
                        await _cartRepository.AddCart(cart);
                    }   
                }
                var hasItem = await _cartRepository.hasItem(cart.CartId, cartItemDto.ProductId);
                if (hasItem){
                    await sumItemCart(cart.CartId, cartItemDto.ProductId);
                }
                else {
                    var existItem = await _productRepository.GetProductById(cartItemDto.ProductId);
                    if (existItem == null)
                    {
                        throw new Exception("El Producto no existe");
                    }
                    var cartItem = new CartItem
                    {
                        ProductId = cartItemDto.ProductId,
                        Quantity = cartItemDto.Quantity,
                        Cart = cart,
                        CartId = cart.CartId
                    };
                    cart.CartItems.Add(cartItem);
                    await _cartRepository.updateCart(cart);
                }
            }
            
        }

        public async Task DeleteCart(int cartId)
        {
            var cart = await _cartRepository.GetCart(cartId);
            if (cartId == 0)
            {
                RemoveCartCookies();
                return;
            }
            if (cart == null)
            {
                throw new Exception("Carrito no existe");
            }
            await _cartRepository.RemoveCart(cartId);
        }

        public async Task<CartDto> GetCartByUserId(int? userId = null)
        {
            if (userId == null)
            {
                var cartCookies = GetCartCookies();
                return new CartDto
                {
                    CartItems = cartCookies.CartItems.Select(ci => new CartItemDto
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity
                    }).ToList(),
                    UserId = null
                };
            }
            else {
                var cart = await _cartRepository.GetCartByUserId(userId.Value);
                if (cart == null)
                {
                    var user = await _userRepository.GetUserById(userId.Value);
                    if (user == null)
                    {
                        throw new Exception("Usuario no existe");
                    }
                    else {
                        cart = new Cart
                        {
                            UserId = userId.Value,
                            User = user
                        };
                        await _cartRepository.AddCart(cart);
                    }   
                }
                return CartMapper.ToCartDTO(cart);
            }
        }

        public async Task substractItemCart(int cartId, int productId)
        {
            var cart = await _cartRepository.GetCart(cartId);
            var cartCookie = GetCartCookies();
            if (cartCookie != null && cartId == 0)
            {
                await substractItemCartCookies(new CartItemDto
                {
                    ProductId = productId,
                    Quantity = 1
                });
                return;
            }
            if (cart != null)
            {
                if (cart.UserId == null)
                {
                    throw new Exception("Carrito no existe");
                }
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem == null)
                {
                   throw new Exception("Id del item no existe en el carrito");
                }
                if (cartItem.Quantity == 1)
                {
                    cart.CartItems.Remove(cartItem);
                    await _cartRepository.updateCart(cart);
                }
                else {
                    cartItem.Quantity--;
                   await _cartRepository.UpdateCartItem(cartItem);
                }
            }
            if (cart == null)
            {
                throw new Exception("Carrito no existe");
            }
        }

        public async Task sumItemCart(int cartId, int productId)
        {
            var cart = await _cartRepository.GetCart(cartId);
            var cartCookie = GetCartCookies();
            if (cartCookie != null && cartId == 0)
            {
                await sumItemCartCookies(new CartItemDto
                {
                    ProductId = productId,
                    Quantity = 1
                });
                return;
            }
            if (cart != null)
            {
                if (cart.UserId == null)
                {
                    throw new Exception("Carrito no existe");
                }
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem == null)
                {
                    throw new Exception("Id del item no existe en el carrito");
                }
                var product = await _productRepository.GetProductById(cartItem.ProductId);
                if (product.Stock < cartItem.Quantity + 1)
                {
                   throw new Exception("No hay suficiente stock para aumentar la cantidad");
                }
                cartItem.Quantity++;
                await _cartRepository.UpdateCartItem(cartItem);
            }
            if (cart == null)
            {
                throw new Exception("Carrito no existe");
            }
        }
        private CartCookiesDto GetCartCookies()
        {
            var cookies = _httpContextAccessor.HttpContext?.Request.Cookies["cart"];
            if (string.IsNullOrEmpty(cookies))
            {
                return new CartCookiesDto();
            }
            else {
                return JsonConvert.DeserializeObject<CartCookiesDto>(cookies);
            }
        }
        private void SetCartCookies(CartCookiesDto cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)
            };
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("cart", cartJson, options);
        }
        private async Task AddCartItemCookies(CartItemDto cartItemDto){
            var cart = GetCartCookies();
            var product = await _productRepository.GetProductById(cartItemDto.ProductId);
            if (product == null)
            {
                throw new Exception("Producto no existe");
            }
            var hasItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItemDto.ProductId);
            if (hasItem == null)
            {
                cart.CartItems.Add(cartItemDto);
                SetCartCookies(cart);
            }
            if (hasItem != null){
                await sumItemCartCookies(cartItemDto);
            }
        }
        private async Task substractItemCartCookies(CartItemDto cartItemDto){
            var cart = GetCartCookies();
            var item = await _productRepository.GetProductById(cartItemDto.ProductId);
            if (item == null)
            {
                throw new Exception("El Producto no existe");
            }
            var existsItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItemDto.ProductId);
            if (existsItem == null){
                return;
            }
            if (existsItem.Quantity == 1)
            {
                cart.CartItems.Remove(existsItem);
                SetCartCookies(cart);
            }
            if (existsItem.Quantity > 1){
                existsItem.Quantity--;
            }
            SetCartCookies(cart);
        }
        private async Task sumItemCartCookies(CartItemDto cartItemDto){
            var cart = GetCartCookies();
            var item = await _productRepository.GetProductById(cartItemDto.ProductId);
            if (item == null)
            {
                throw new Exception("El Producto no existe");
            }
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItemDto.ProductId);
            if (cartItem == null)
            {
                throw new Exception("El Producto no existe en el carrito");
            }
            if (item.Stock < cartItem.Quantity + 1)
            {
                throw new Exception("No hay suficiente stock para aumentar la cantidad");
            }
            cartItem.Quantity++;
            SetCartCookies(cart);
        }
        private void RemoveCartCookies(){
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("cart");
        }
    }   
}