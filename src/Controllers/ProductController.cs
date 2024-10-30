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
    }
}