using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ?RUT { get; set; }
        public string ?Name { get; set; }
        public string ?Email { get; set; }
        public string ?Gender { get; set; }
        public string ?birthday { get; set; }
        public string ?Password { get; set; }
    }
}