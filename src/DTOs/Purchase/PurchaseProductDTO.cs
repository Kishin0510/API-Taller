using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.Purchase
{
    public class PurchaseProductDTO
    {
       /// <summary>
        /// Id del producto.
        /// </summary>
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        /// <summary>
        /// Tipo del producto.
        /// </summary>
        public string ProductType { get; set; } = null!;

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Cantidad del producto.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Precio total del producto (Precio * Cantidad).
        /// </summary>
        public int TotalPrice { get; set; }
    }
}