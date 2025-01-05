using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Cart;
using Api_Taller.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api_Taller.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        
        [HttpGet("getCart")]
        public async Task<ActionResult> GetCart([FromQuery] int? userId)
        {
            try {
                var result = await _cartService.GetCartByUserId(userId);
                return Ok(result);
            } catch (Exception e) {
                return BadRequest(new {Message = e.Message});
            }
        }
        [HttpPost("addItemCart")]
        public async Task<ActionResult> AddItemCart([FromBody] CartItemDto cartItemDto, [FromQuery] int? userId)
        {
            try {
                await _cartService.AddItemCart(cartItemDto, userId);
                return Ok(new {Message = "Producto agregado al carrito"});
            } catch (Exception e) {
                return BadRequest(new {Message = e.Message});
            }
        }
        [HttpDelete("deleteCart")]
        public async Task<ActionResult> DeleteCart([FromQuery] int cartId)
        {
            try {
                await _cartService.DeleteCart(cartId);
                return Ok(new {Message = "Carrito eliminado"});
            } catch (Exception e) {
                return BadRequest(new {Message = e.Message});
            }
        }
        [HttpPost("sumItemCart")]
        public async Task<ActionResult> SumItemCart([FromQuery] int cartId, [FromQuery] int productId)
        {
            try {
                await _cartService.sumItemCart(cartId, productId);
                return Ok(new {Message = "Producto sumado al carrito"});
            } catch (Exception e) {
                return BadRequest(new {Message = e.Message});
            }
        }
        [HttpPost("subtractItemCart")]
        public async Task<ActionResult> SubtractItemCart([FromQuery] int cartId, [FromQuery] int productId)
        {
            try {
                await _cartService.substractItemCart(cartId, productId);
                return Ok(new {Message = "Producto restado al carrito"});
            } catch (Exception e) {
                return BadRequest(new {Message = e.Message});
            }
        }
    }
}