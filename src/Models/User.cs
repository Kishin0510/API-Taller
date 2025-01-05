using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class User
    {
        /// <summary>
        /// Id del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RUT del usuario.
        /// </summary>
        public string RUT { get; set; } = null!;

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Correo del usuario.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Cumpleaños del usuario.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Estado del usuario.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// Entity Framework Relations
        /// <summary>
        /// Id del rol. 
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public Role Role { get; set; } = null!;

        /// <summary>
        /// Id del género.
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Género del usuario.
        /// </summary>
        public Gender Gender { get; set; } = null!;

        /// <summary>
        /// Carrito del usuario.
        /// </summary>
        public Cart? Cart { get; set; }
    }
}