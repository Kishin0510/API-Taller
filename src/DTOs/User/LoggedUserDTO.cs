using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.User
{
    public class LoggedUserDTO
    {
        /// <summary>
        /// Usuario loggeado.
        /// </summary>
        public required UserDTO User { get; set; }

        /// <summary>
        /// Token de autenticación.
        /// </summary>
        public required string Token { get; set; }          
    }
}