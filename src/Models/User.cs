using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string RUT { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Password { get; set; } = null!;
        public bool IsEnabled { get; set; } = true;
        // Entity Framework Relations
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public int GenderId { get; set; }
        public Gender Gender { get; set; } = null!;
    }
}