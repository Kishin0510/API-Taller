using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.DTOs.Purchase
{
    public class AddPurchaseDTO
    {
        /// <summary>
        /// Lista de ids de los productos.
        /// </summary>
        public List<int> ProductIds { get; set; } = new List<int>();

        /// <summary>
        /// Lista de cantidades de los productos.
        /// </summary>
        public List<int> Quantities { get; set; } = new List<int>();
        
        /// <summary>
        /// País del usuario.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "El nombre del país debe tener al menos 1 caracter.")]
        [MaxLength(64, ErrorMessage = "El nombre del país debe tener a lo más 64 caracteres.")]
        public string Country { get; set; } = null!;   

        /// <summary>
        /// Ciudad del usuario.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "El nombre de la ciudad debe tener al menos 1 caracter.")]
        [MaxLength(64, ErrorMessage = "El nombre de la ciudad debe tener a lo más 64 caracteres.")]
        public string City { get; set; } = null!;

        /// <summary>
        /// Comuna del usuario.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "El nombre de la comuna debe tener al menos 1 caracter.")]
        [MaxLength(64, ErrorMessage = "El nombre de la comuna debe tener a lo más 64 caracteres.")]
        public string Commune { get; set; } = null!;

        /// <summary>
        /// Calle del usuario.
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "El nombre de la calle debe tener al menos 1 caracter.")]
        [MaxLength(64, ErrorMessage = "El nombre de la calle debe tener a lo más 64 caracteres.")]
        public string Street { get; set; } = null!;
    }
}