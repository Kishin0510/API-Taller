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
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<string>> CreatePurchase([FromBody] AddPurchaseDTO purchaseDTO)
        {
            //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userIdClaim = "1";
            if (userIdClaim != null)
            {
                if (int.TryParse(userIdClaim, out var userId))
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
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchaseById(int id)
        {
            var purchase = await _purchaseService.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound("Compra no encontrada");
            }
            return Ok(purchase);
        }
        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetAllPurchases()
        {
            var purchases = await _purchaseService.GetAllPurchases();
            return Ok(purchases);
        }
    }
}