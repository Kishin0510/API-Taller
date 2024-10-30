using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task<bool> ValidProductType(int id);
        Task<ProductType?> GetProductType(int id);
    }
}