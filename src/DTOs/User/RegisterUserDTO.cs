using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Api_Taller.src.Helpers.Validators;


namespace Api_Taller.src.DTOs.User
{
    public class RegisterUserDTO
    {
        [RutValidatorAtrribute]
        public string Rut { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(8, ErrorMessage = "Nombre debe tener al menos 8 caracteres")]
        [MaxLength(255, ErrorMessage = "Nombre debe tener a lo más 255 caracteres")]
        public string Name { get; set; } = string.Empty;

             
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es correcto")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Género es obligatorio.")]
        [GenderValidator]
        public string GenderId { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener al menos 8 caracteres.")]
        [MaxLength(20, ErrorMessage = "La Contraseña debe tener a lo más 20 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Las Contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;    
    }
}