using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.User
{
    public class UserDTO
    {
        /// <summary>
        /// Id del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rut del usuario.
        /// </summary>
        public string Rut { get; set; } = null!;

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Correo del usuario.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Fecha de nacimiento del usuario.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Estado del usuario.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Género del usuario.
        /// </summary>
        public Gender Gender { get; set; } = null!;

        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public Role Rol { get; set; } = null!;

    }
}