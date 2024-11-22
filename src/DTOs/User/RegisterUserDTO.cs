using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Api_Taller.src.Helpers.Validators;


namespace Api_Taller.src.DTOs.User
{
    public class RegisterUserDTO
    {
        /// <summary>
        /// Rut del usuario.
        /// </summary>
        [RutValidatorAtrribute]
        public string Rut { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(8, ErrorMessage = "Nombre debe tener al menos 8 caracteres")]
        [MaxLength(255, ErrorMessage = "Nombre debe tener a lo más 255 caracteres")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Cumpleaños del usuario.
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es correcto")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Id del género del usuario.
        /// </summary>
        [Required(ErrorMessage = "El Género es obligatorio.")]
        [GenderValidator]
        public string GenderId { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener al menos 8 caracteres.")]
        [MaxLength(20, ErrorMessage = "La Contraseña debe tener a lo más 20 caracteres.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Confirmación de la contraseña del usuario.
        /// </summary>
        [Compare("Password", ErrorMessage = "Las Contraseñas no coinciden.")]
        [Required(ErrorMessage = "La Confirmación de la Contraseña es obligatoria.")]
        public string ConfirmPassword { get; set; } = string.Empty;    
    }
}