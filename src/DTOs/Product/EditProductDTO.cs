using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Product
{
    public class EditProductDTO
    {
        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [MinLength(10, ErrorMessage = "El Nombre debe tener al menos 10 caracteres.")]
        [MaxLength(64, ErrorMessage = "El Nombre debe tener a lo más 64 caracteres.")]
        public string? Name { get; set; }
        
        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Range(1, 100000000, ErrorMessage = "El campo Precio debe ser mayor a 0 y menor a 100 millones")]
        public int? Price { get; set; } 

        /// <summary>
        /// Stock del producto.
        /// </summary>
        [Range(1, 100000, ErrorMessage = "El campo Stock debe ser mayor a 0 y menor a 100 mil")]
        public int? Stock { get; set; }

        /// <summary>
        /// La imagen a subir.
        /// </summary>
        public IFormFile? Image { get; set; }

        /// <summary>
        /// Id del tipo de producto.
        /// </summary>
        public int? ProductTypeId { get; set; }        
    }
}