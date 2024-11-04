using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Product
{
    public class AddProductDTO
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(64, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres")]
        [MinLength(10, ErrorMessage = "El campo Nombre no puede tener menos de 3 caracteres")]
        public required string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo Precio es requerido")]
        [Range(1, 100000000, ErrorMessage = "El campo Precio debe ser mayor a 0 y menor a 100 millones")]
        public required int Price { get; set; } = 0;

        [Required(ErrorMessage = "El campo Stock es requerido")]
        [Range(1, 100000, ErrorMessage = "El campo Stock debe ser mayor a 0 y menor a 100 mil")]
        public required int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El campo Imagen es requerido")]
        public required IFormFile Image { get; set;}

        [Required(ErrorMessage = "El campo Tipo de Producto es requerido")]
        public required int ProductTypeId { get; set; } = 0;
    }
}