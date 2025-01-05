using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.Cart
{
    public class CartDto
    {
        /// <summary>
        /// Id del carrito.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Lista de items del carrito.
        /// </summary>
        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

        /// <summary>
        /// Id del usuario propietario del carrito.
        /// </summary>
        public int? UserId { get; set; }
    }
}