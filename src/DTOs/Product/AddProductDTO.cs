using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Product
{
    public class AddProductDTO
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public required string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo Precio es requerido")]
        public required int Price { get; set; } = 0;

        [Required(ErrorMessage = "El campo Stock es requerido")]
        public required int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El campo Imagen es requerido")]
        public required IFormFile Image { get; set;}

        [Required(ErrorMessage = "El campo Tipo de Producto es requerido")]
        public required int ProductTypeId { get; set; } = 0;
    }
}