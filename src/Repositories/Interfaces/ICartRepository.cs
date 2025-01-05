using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface ICartRepository
    {
        /// <summary>
        /// Obtienes un carrito de compra segun su id.
        /// </summary>
        /// <param name="cartId">Id del carrito de compra. </param>
        /// <returns>Carrito de compra segun su id</returns>
        Task<Cart?> GetCart(int cartId);

        /// <summary>
        /// Obtiene un carrito de compra segun el id del usuario.
        /// </summary>
        /// <param name="userId">Id del usuario. </param>
        /// <returns>Carrito de compra segun la id del usuario</returns>
        Task<Cart?> GetCartByUserId(int userId);

        /// <summary>
        /// Agrega un carrito de compra a la base de datos
        /// </summary>
        /// <param name="cart">Carrito de compra a agregar. </param>
        /// <returns></returns>
        Task AddCart(Cart cart);

        /// <summary>
        /// Elimina un carrito de compra de la base de datos.
        /// </summary>
        /// <param name="cartId">Carrito de compra a eliminar.</param>
        /// <returns></returns>
        Task RemoveCart(int cartId);

        /// <summary>
        /// Actualiza un carrito de compra.
        /// </summary>
        /// <param name="cart">Carrito de compra a actualizar.</param>
        /// <returns></returns>
        Task updateCart(Cart cart);

        /// <summary>
        /// Agrega un item al carrito de compra
        /// </summary>
        /// <param name="cartItem">Item del carrito con un producto y cantidad.</param>
        /// <returns></returns>
        Task AddCartItem(CartItem cartItem);

        /// <summary>
        /// Elimina un item del carrito de compra.
        /// </summary>
        /// <param name="cartItemId">Item del carrito con un producto y cantidad.</param>
        /// <returns></returns>
        Task RemoveCartItem(int cartItemId);

        /// <summary>
        /// Actualiza un item del carrito de compra.
        /// </summary>
        /// <param name="cartItem">Item del carrito con un producto y cantidad.</param>
        /// <returns></returns>
        Task UpdateCartItem(CartItem cartItem);

        /// <summary>
        /// Verifica si un item existe en el carrito de compra.
        /// </summary>
        /// <param name="cartId">Id del carrito donde se buscara el item.</param>
        /// <param name="productId">Id del producto que se buscara en el carrito</param>
        /// <returns>true en caso que exista en el carrito, false en caso contrario</returns>
        Task<bool> hasItem(int cartId, int productId);
    }
}