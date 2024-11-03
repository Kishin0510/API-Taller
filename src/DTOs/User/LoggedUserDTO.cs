using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.User
{
    public class LoggedUserDTO
    {
        public required UserDTO User { get; set; }
        public required string Token { get; set; }          
    }
}