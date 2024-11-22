using System.Runtime.CompilerServices;
using Api_Taller.src.Models;
using Api_Taller.src.DTOs.Product;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IProductRepository
    {

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Lista de productos. </returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Lista de productos. </returns>
        Task<IEnumerable<Product>> GetAvailableProducts();

        /// <summary>
        /// Se obtiene un producto por su id.
        /// </summary>
        /// <param name="id">La id del producto. </param>
        /// <returns>Un producto en el caso de existir. </returns>
        Task<Product?> GetProductById(int id);

        /// <summary>
        /// Se agrega un producto.
        /// </summary>
        /// <param name="product">Producto que se añade. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> AddProduct(Product product);

        /// <summary>
        /// Se elimina un producto.
        /// </summary>
        /// <param name="id">La ide del producto a eliminar. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> DeleteProduct(int id); // Se elimina un producto

        /// <summary>
        /// Actualizar un producto. 
        /// </summary>
        /// <param name="id">La id del producto a actualizar. </param>
        /// <param name="editProduct">La información a editar del producto. </param>
        /// <param name="imageUrl">La nueva url de la imagen. </param>
        /// <param name="imageId">La nueva id de la imagen. </param>
        /// <returns></returns>
        Task<bool> UpdateProduct(int id, EditProductDTO editProduct, string? imageUrl, string? imageId);

        /// <summary>
        /// Obtiene todos los productos de un tipo.
        /// </summary>
        /// <param name="type">La id del tipo a buscar. </param>
        /// <returns>Lista de productos de ese tipo. </returns>
        Task<IEnumerable<Product>> GetProductsByType(int type); 

        /// <summary>
        /// Obtiene todos los productos ordenados de forma ascendente. 
        /// </summary>
        /// <returns>Lista de productos ordenados de forma ascendente. </returns>
        Task<IEnumerable<Product>> SortProductAscendant(); 

        /// <summary>
        /// Obtiene todos los productos ordenados de forma descendente.
        /// </summary>
        /// <returns>Lista de productos ordenados de forma descendente. </returns>
        Task<IEnumerable<Product>> SortProductDescendant();

        /// <summary>
        /// Obtiene todos los productos de un tipo ordenados de forma ascendente.
        /// </summary>
        /// <param name="type">La id del tipo. </param>
        /// <returns>Lista de productos del tipo ordenados de forma ascendente. </returns>
        Task<IEnumerable<Product>> GetProductsByTypeAndSortAscendant(int type);

        /// <summary>
        /// Obtiene todos los productos de un tipo ordenados de forma descendente.
        /// </summary>
        /// <param name="type">La id del tipo. </param>
        /// <returns>Lista de productos del tipo ordenados de forma descendente. </returns>
        Task<IEnumerable<Product>> GetProductsByTypeAndSortDescendant(int type);

        /// <summary>
        /// Valida si un producto existe por su nombre y tipo. 
        /// </summary>
        /// <param name="name">Nombre del producto. </param>
        /// <param name="productTypeId">La id del tipo de producto. </param>
        /// <returns></returns>
        Task<bool> ValidProductByNameAndType(string name, int productTypeId); // Se valida si un producto existe por su nombre y tipo
    }
}