using System.Runtime.CompilerServices;
using Api_Taller.src.Models;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(); // Se obtienen todos los productos

        Task<IEnumerable<Product>> GetAvailableProducts(); // Se obtienen todos los productos disponibles

        Task<Product?> GetProductById(int id); // Se obtiene un producto por su id

        Task<bool> AddProduct(Product product); // Se agrega un producto

        Task<bool> DeleteProduct(int id); // Se elimina un producto

        Task<bool> UpdateProduct(int id, EditProductDTO editProduct); // Se actualiza un producto

        Task<IEnumerable<Product>> GetProductsByType(string type); // Se obtienen todos los productos de un tipo

        Task<IEnumerable<Product>> SortProductAscendant(); // Se obtienen todos los productos ordenados de forma ascendente

        Task<IEnumerable<Product>> SortProductDescendant(); // Se obtienen todos los productos ordenados de forma descendente

        Task<IEnumerable<Product>> GetProductsByTypeAndSortAscendant(string type); // Se obtienen todos los productos de un tipo ordenados de forma ascendente

        Task<IEnumerable<Product>> GetProductsByTypeAndSortDescendant(string type); // Se obtienen todos los productos de un tipo ordenados de forma descendente

        Task<bool> ValidProductByNameAndType(string name, int productTypeId); // Se valida si un producto existe por su nombre y tipo
    }
}