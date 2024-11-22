using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.User
{
    public class EditUserDTO
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Cumpleaños del usuario.
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Id del género del usuario.
        /// </summary>
        public int? GenderId { get; set; }
    }
}