using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Product
{
    public class EditProductDTO
    {
        [MinLength(10, ErrorMessage = "El Nombre debe tener al menos 10 caracteres.")]
        [MaxLength(64, ErrorMessage = "El Nombre debe tener a lo más 64 caracteres.")]
        public string? Name { get; set; }

        public string? Price { get; set; } 

        public string? Stock { get; set; }

        public IFormFile? Image { get; set; }

        public string? ProductTypeId { get; set; }        
    }
}