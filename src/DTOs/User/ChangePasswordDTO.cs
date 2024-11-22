using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.User
{
    public class ChangePasswordDTO
    {
        /// <summary>
        /// Contraseña anterior del usuario.
        /// </summary>
        [Required(ErrorMessage = "Es obligatoria la contraseña anterior.")]
        public string OldPassword { get; set; } = string.Empty;

        /// <summary>
        /// Nueva contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [MaxLength(20, ErrorMessage = "La contraseña debe tener a lo más 20 caracteres.")]
        public string NewPassword { get; set; } = string.Empty;
        
        /// <summary>
        /// Confirmación de la nueva contraseña del usuario.
        /// </summary>
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}