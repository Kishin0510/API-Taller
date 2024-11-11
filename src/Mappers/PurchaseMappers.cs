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
                PurchaseDate = purchaseModel.PurchaseDate,
                TotalPrice = purchaseModel.TotalPrice,
                UserId = purchaseModel.UserId,
                Country = purchaseModel.Country,
                City = purchaseModel.City,
                Commune = purchaseModel.Commune,
                Street = purchaseModel.Street,
                Quantities = purchaseModel.Quantities
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
                Quantities = addpurchaseDTO.Quantities
            };
        }
    }
}