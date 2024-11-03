using Microsoft.AspNetCore.Mvc;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Models;
using Api_Taller.src.DTOs.Product;

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

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("available/{pageNum}/{pageSize}")]
        public ActionResult<IEnumerable<ProductDTO>> GetAvailableProducts(int pageNum, int pageSize)
        {
            var products = _productService.GetAvailableProducts(pageNum, pageSize);
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
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

        [HttpPut("{id: int}")]
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

        [HttpDelete("{id: int}")]
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

        [HttpGet("available/search")]
        public ActionResult<IEnumerable<ProductDTO>> SearchAvailableProducts([FromQuery] string query, [FromQuery] string order)
        {
            var products = _productService.SearchAvailableProducts(query, order);
            return Ok(products);
        }
    }
}