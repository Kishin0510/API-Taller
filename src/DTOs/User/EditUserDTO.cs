using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.User
{
    public class EditUserDTO
    {
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? GenderId { get; set; }
    }
}