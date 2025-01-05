using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class CartItem
    {
        /// <summary>
        /// Id del item del carrito.
        /// </summary>
        public int CartItemId { get; set; }

        /// <summary>
        /// Cantidad del producto en el carrito.
        /// </summary>
        public int Quantity { get; set; }

        ///Entity Framework Relations
        /// <summary>
        /// Id del carrito al que pertenece el item.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Carrito al que pertenece el item.
        /// </summary>
        [JsonIgnore]
        public Cart Cart { get; set; }

        /// <summary>
        /// Id del producto en el carrito.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Producto en el carrito.
        /// </summary>
        public Product Product { get; set; }
    }
}