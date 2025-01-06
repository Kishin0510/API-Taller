using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;
using Api_Taller.src.DTOs.Purchase;
using Api_Taller.src.Models;

namespace Api_Taller.src.Mappers
{
    public static class PurchaseMapper
    {
        public static PurchaseDTO ToPurchaseDto(this Purchase purchaseModel)
        {
            return new PurchaseDTO
            {
                Id = purchaseModel.Id,
                PurchaseDate = purchaseModel.PurchaseDate.ToString("dd-MM-yyyy"),
                TotalPrice = purchaseModel.TotalPrice,
                UserId = purchaseModel.UserId,
                UserName = purchaseModel.User?.Name ?? "No User",
                Country = purchaseModel.Country,
                City = purchaseModel.City,
                Commune = purchaseModel.Commune,
                Street = purchaseModel.Street,
                PurchaseProducts = purchaseModel.PurchaseProducts.Select(p => new PurchaseProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.Product?.Name ?? "Desconocido",
                    ProductType = p.Product?.ProductType?.Type ?? "Desconocido",
                    Price = p.Product?.Price ?? 0,
                    Quantity = p.Quantity,
                    TotalPrice = (p.Product?.Price ?? 0) * p.Quantity
                }).ToList()
            };
        }
        public static Purchase ToPurchaseModel(this AddPurchaseDTO addpurchaseDTO)
        {
            return new Purchase
            {
                PurchaseDate = DateTime.Now,
                Country = addpurchaseDTO.Country,
                City = addpurchaseDTO.City,
                Commune = addpurchaseDTO.Commune,
                Street = addpurchaseDTO.Street,
                
            };
        }
    }
}