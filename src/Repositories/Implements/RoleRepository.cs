using Api_Taller.src.Models;
using Api_Taller.src.Data;
using Api_Taller.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api_Taller.src.Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDBContext _context;

        public RoleRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Role?> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role;
        }

        public async Task<Role?> GetRoleByName(string type)
        {
            var role = await _context.Roles.Where(r => r.Name == type).FirstOrDefaultAsync();
            return role;
        }

        public async Task<bool> ValidRoleId(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role != null;
        }
    }
}