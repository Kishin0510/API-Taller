using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.DTOs.Cart
{
    public class CartItemDto
    {
        /// <summary>
        /// Id del producto en el carrito.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad del producto en el carrito.
        /// </summary>
        public int Quantity { get; set; }
    }
}