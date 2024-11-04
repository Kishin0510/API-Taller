using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller.src.Repositories.Implements
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDBContext _context;
        public GenderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var genders = await  _context.Genders.ToListAsync();
            return genders;
        }

        public async Task<bool> ValidGenderId(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null){
                return false;
            }
            return true;
        }
    }
}