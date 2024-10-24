using Microsoft.EntityFrameworkCore;
using Api_Taller.src.Models;
using Api_Taller.src.Data;
using Api_Taller.src.Interfaces;

namespace Api_Taller.src.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            if(product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAvailableProducts()
        {
            var products = await _context.Products.Where(p => p.Stock > 0).ToListAsync();
            return products;
        }

        public Task<Product?> GetProductById(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(); 
            if(product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return product; 
            
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByType(string type)
        {
            var products = await GetAvailableProducts();
            if (!string.IsNullOrEmpty(type))
            {
                products = products.Where(p => p.ProductType.Type == type).ToList();
            }
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeAndSortAscendant(string type)
        {
            var products = await GetAvailableProducts();
            if(!string.IsNullOrEmpty(type))
            {
                products = products.Where(p => p.ProductType.Type == type).OrderBy(p => p.Price).ToList();
            }
            return products; // Arreglar
        }

        public Task<IEnumerable<Product>> GetProductsByTypeAndSortDescendant(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SortProductAscendant()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SortProductDescendant()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}