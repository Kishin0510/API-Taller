using Api_Taller.src.DTOs.Purchase;
using Api_Taller.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Taller.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// Crea una boleta de compra. 
        /// </summary>
        /// <param name="purchaseDTO">La información de la compra. </param>
        /// <returns>Un mensaje de confirmación. </returns>
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<string>> CreatePurchase([FromBody] AddPurchaseDTO purchaseDTO)
        {
            var userIdToken = User.FindFirst("Id")?.Value;
            if (userIdToken != null)
            {
                if (int.TryParse(userIdToken, out var userId))
                {
                    var valor = await _purchaseService.CreatePurchase(purchaseDTO, userId);
                    if (valor)
                    {
                        return Ok("Compra realizada correctamente");
                    }
                    return BadRequest("Error al encontrar el usuario");
                }
            return BadRequest("Usuario no autenticado");
            }
            return BadRequest("Error al realizar la compra");
        }

        /// <summary>
        /// Obtiene las compras del usuario. 
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <returns>Lista de compras del usuario. </returns>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPurchaseById(int id)
        {
            var idClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Id");
            if (idClaim != null && int.Parse(idClaim.Value) != id)
            {
                return Unauthorized("No puedes ver las compras de otro usuario");
            }
            var purchase = await _purchaseService.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound("Compras no encontradas");
            }
            return Ok(purchase);
        }

        /// <summary>
        /// Obtiene todas las compras con posibilidad de paginar los resultados.
        /// </summary>
        /// <param name="pageNum">El número de la página. </param>
        /// <param name="pageSize">El tamaño de la página. </param>
        /// <returns>Una lista con las compras. </returns>
        [HttpGet("{pageNum:int}/{pageSize:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllPurchases(int pageNum, int pageSize)
        {
            var purchases = await _purchaseService.GetAllPurchases(pageNum, pageSize);
            return Ok(purchases);
        }

        /// <summary>
        /// Busca compras por nombre y fecha.
        /// </summary>
        /// <param name="name">Nombre de usuario a buscar. </param>
        /// <param name="date">La fecha a buscar. </param>
        /// <returns></returns>
        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> SearchPurchases([FromQuery] string name, [FromQuery] string date)
        {
            var purchases = await _purchaseService.SearchPurchases(name, date);
            return Ok(purchases);
        }
    }
}