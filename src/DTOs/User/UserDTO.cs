using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; } = null!;
        public Role Rol { get; set; } = null!;

    }
}