using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NameRol { get; set; } = null!;
        public List<ProductDTO> Products { get; set; } = [];
    }
}