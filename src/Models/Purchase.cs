using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Purchase
    {
        /// <summary>
        /// Id de la compra.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de la compra.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Precio total de la compra.
        /// </summary>
        public int TotalPrice { get; set; } = 0;

        /// <summary>
        /// País del usuario. 
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Ciudad del usuario.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Comuna del usuario.
        /// </summary>
        public string Commune { get; set; } = null!;

        /// <summary>
        /// Calle del usuario.
        /// </summary>
        public string Street { get; set; } = null!;

        /// Entity Framework Relations 
        /// <summary>
        /// Id del usuario.
        /// </summary>        
        public int UserId { get; set; }

        /// <summary>
        /// Usuario de la compra. 
        /// </summary>
        public User ?User { get; set; }

        /// <summary>
        /// Lista de productos de la compra.
        /// </summary>
        public List<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
        
    }
}