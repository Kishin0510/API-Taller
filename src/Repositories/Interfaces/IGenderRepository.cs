using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetGenders();

        Task<bool> ValidGenderId(int id);  
    }
}