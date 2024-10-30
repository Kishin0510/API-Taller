using Api_Taller.src.Models;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.DTOs;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductService(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public Task<bool> AddProduct(AddProductDTO addProductDTO)
        {
            if (!_productTypeRepository.ValidProductType(addProductDTO.ProductTypeId).Result) 
            {
                throw new Exception("Tipo de producto no válido");
            }
            if (_productRepository.ValidProductByNameAndType(addProductDTO.Name, addProductDTO.ProductTypeId).Result)
            {
                throw new Exception("Un producto con el mismo nombre y tipo ya existe");
            }

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