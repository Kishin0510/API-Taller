using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;
using Api_Taller.src.DTOs.Purchase;
using Api_Taller.src.DTOs.User;
using Api_Taller.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SQLitePCL;

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
        [HttpGet("{id}")]
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
        [HttpGet("{pageNum}/{pageSize}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllPurchases(int pageNum, int pageSize)
        {
            var purchases = await _purchaseService.GetAllPurchases(pageNum, pageSize);
            return Ok(purchases);
        }

        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> SearchPurchases([FromQuery] string name, [FromQuery] string date)
        {
            var purchases = await _purchaseService.SearchPurchases(name, date);
            return Ok(purchases);
        }
    }
}