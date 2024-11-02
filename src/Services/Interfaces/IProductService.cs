using Api_Taller.src.DTOs.Product;
using Api_Taller.src.Models;

namespace Api_Taller.src.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<IEnumerable<ProductDTO>> GetAvailableProducts(int pageNum, int pageSize);

        Task<IEnumerable<ProductDTO>> SearchProducts(string query);

        Task<IEnumerable<ProductDTO>> SearchAvailableProducts(string query);

        Task<bool> AddProduct(AddProductDTO addProductDTO);

        Task<bool> EditProduct(int id, EditProductDTO editProductDTO);

        Task<bool> DeleteProduct(int id);
    }
}