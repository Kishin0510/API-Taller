using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller.src.Repositories.Implements
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<ProductType?> GetProductType(int id)
        {
            var productType = _context.ProductTypes.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(productType == null)
            {
                throw new Exception("Tipo de producto no encontrado");
            }
            return productType;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }

        public async Task<bool> ValidProductType(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            return productType != null;
        }
    }
}