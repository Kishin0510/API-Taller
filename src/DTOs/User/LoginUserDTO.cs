using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.User
{
    public class LoginUserDTO
    {
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        [Required(ErrorMessage = "El Correo electrónico es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set;} = string.Empty; 
    }
}