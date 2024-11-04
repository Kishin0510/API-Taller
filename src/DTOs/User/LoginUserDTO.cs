using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.User
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage = "El Correo electrónico es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set;} = string.Empty; 
    }
}