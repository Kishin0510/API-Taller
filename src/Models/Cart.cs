using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Cart
    {
        /// <summary>
        /// Id del carrito.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Lista de items del carrito.
        /// </summary>
        public List <CartItem> CartItems { get; set; } = new List<CartItem>();


        ///Entity Framework Relations
        /// <summary>
        /// Id del usuario propietario del carrito.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Usuario propietario del carrito (Puede ser nulo en caso que el usuario no inicie sesión).
        /// </summary>
        public User? User { get; set; }
    }
}