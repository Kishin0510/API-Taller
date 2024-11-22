using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class PurchaseProduct
    {
        /// <summary>
        /// Id del carrito.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id de la compra.
        /// </summary>
        public int PurchaseId { get; set; }

        /// <summary>
        /// Id del producto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad de productos.
        /// </summary>
        public int Quantity { get; set; }

        /// Entity Framework Relations
        /// <summary>
        /// Producto del carrito.
        /// </summary>
        public Product Product { get; set; } = null!;
    
        /// <summary>
        /// Compra del carrito.
        /// </summary>
        public Purchase Purchase { get; set; } = null!;
    }
}