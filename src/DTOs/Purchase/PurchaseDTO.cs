using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;
using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.Purchase
{
    public class PurchaseDTO
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
        public int TotalPrice { get; set; }

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

        /// <summary>
        /// Id del usuario.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Lista de productos de la compra.
        /// </summary>
        public List<PurchaseProductDTO> PurchaseProducts { get; set; } = new List<PurchaseProductDTO>();
    }
}