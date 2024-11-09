using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                PurchaseDate = purchaseModel.PurchaseDate,
                TotalPrice = purchaseModel.TotalPrice,
                UserId = purchaseModel.UserId,
                ProductList = purchaseModel.ProductList.Select(p => p.ToProductDTO()).ToList(),
                Country = purchaseModel.Country,
                City = purchaseModel.City,
                Comune = purchaseModel.Commune,
                Street = purchaseModel.Street,
                Quantities = purchaseModel.Quantities
            };
        }
    }
}