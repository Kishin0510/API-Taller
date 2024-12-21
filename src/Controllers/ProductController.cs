using Microsoft.AspNetCore.Mvc;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Models;
using Api_Taller.src.DTOs.Product;
using Microsoft.AspNetCore.Authorization;

namespace Api_Taller.src.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtiene los productos con posiblidad de filtrar y paginar los resultados.
        /// </summary>
        /// <param name="query">La query de busqueda. </param>
        /// <param name="pageNum">El numero de la página. </param>
        /// <param name="pageSize">El tamaño de la página</param>
        /// <returns>Una lista con los productos. </returns>
        [HttpGet("search/{pageNum:int}/{pageSize:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts([FromQuery] string? query, int pageNum, int pageSize)
        {
            var products = _productService.SearchProducts(query, pageNum, pageSize);
            return Ok(products);
        }

        /// <summary>
        /// Obtiene los productos disponibles con posiblidad de paginar los resultados.
        /// </summary>
        /// <param name="pageNum">El número de la página. </param>
        /// <param name="pageSize">El tamaño de la página. </param>
        /// <returns>Una lista con los productos. </returns>
        [HttpGet("available/{pageNum:int}/{pageSize:int}")]
        public ActionResult<IEnumerable<ProductDTO>> GetAvailableProducts([FromQuery]string? query, [FromQuery]string? order, int pageNum, int pageSize)
        {
            try {
                var products = _productService.GetAvailableProducts(query, order, pageNum, pageSize);
                return Ok(products);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Añadir un producto. 
        /// </summary>
        /// <param name="addProductDTO">La información del producto a añadir. </param>
        /// <returns>Un mensaje de confirmación. </returns>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AddProduct([FromForm] AddProductDTO addProductDTO)
        {
            try {
                var valor = await _productService.AddProduct(addProductDTO);
                return Ok("Producto agregado correctamente");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }	

        /// <summary>
        /// Editar un producto.
        /// </summary>
        /// <param name="id">La id del producto a editar. </param>
        /// <param name="editProductDTO">La información a editar del producto. </param>
        /// <returns>Un mensaje de confirmación. </returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> EditProduct(int id, [FromForm] EditProductDTO editProductDTO)
        {
            try {
                var valor = await _productService.EditProduct(id, editProductDTO);
                return Ok("Producto editado correctamente");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Eliminar un producto. 
        /// </summary>
        /// <param name="id">La id del producto a editar. </param>
        /// <returns>Un mensaje de confirmación. </returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]   
        public async Task<ActionResult<string>> DeleteProduct(int id)
        {
            try {
                var valor = await _productService.DeleteProduct(id);
                return Ok("Producto eliminado correctamente");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar productos disponibles con una query y orden de los datos.
        /// </summary>
        /// <param name="query">La query de búsqueda. </param>
        /// <param name="order">El orden de los productos (asc o desc)</param>
        /// <returns>Lista de productos. </returns>
        [HttpGet("available/search")]
        public ActionResult<IEnumerable<ProductDTO>> SearchAvailableProducts([FromQuery] string query, [FromQuery] string order)
        {
            var products = _productService.SearchAvailableProducts(query, order);
            return Ok(products);
        }


    }
}