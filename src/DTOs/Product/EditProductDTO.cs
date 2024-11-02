using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Product
{
    public class EditProductDTO
    {
        [MinLength(10, ErrorMessage = "El Nombre debe tener al menos 10 caracteres.")]
        [MaxLength(64, ErrorMessage = "El Nombre debe tener a lo más 64 caracteres.")]
        public string? Name { get; set; }

        public int? Price { get; set; } 

        public int? Stock { get; set; }

        public IFormFile? Image { get; set; }

        public int? ProductTypeId { get; set; }        
    }
}