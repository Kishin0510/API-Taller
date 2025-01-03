using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// Cantidad del producto.
        /// </summary>
        public int Quantity { get; set; }
    }
}