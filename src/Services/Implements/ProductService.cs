using Api_Taller.src.Models;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.DTOs;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.Services.Implements
{
    public class ProductService : IProductService
    {

        public Task<bool> AddProduct(AddProductDTO addProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditProduct(int id, EditProductDTO editProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAvailableProducts(int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> SearchAvailableProducts(string query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> SearchProducts(string query)
        {
            throw new NotImplementedException();
        }
    }
}