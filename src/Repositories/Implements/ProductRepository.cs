using Microsoft.EntityFrameworkCore;
using Api_Taller.src.Models;
using Api_Taller.src.Data;
using Api_Taller.src.Repositories.Interfaces;

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
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeAndSortDescendant(string type)
        {
            var products = await GetAvailableProducts();
            if(!string.IsNullOrEmpty(type))
            {
                products = products.Where(p => p.ProductType.Type == type).OrderByDescending(p => p.Price).ToList();
            }
            return products;
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SortProductAscendant()
        {
            var products = await GetAvailableProducts();
            return products.OrderBy(p => p.Price).ToList();
        }

        public async Task<IEnumerable<Product>> SortProductDescendant()
        {
            var products = await GetAvailableProducts();
            return products.OrderByDescending(p => p.Price).ToList();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}