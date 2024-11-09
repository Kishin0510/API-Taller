using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Purchase;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Mappers;

namespace Api_Taller.src.Services.Implements
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public Task<int> CreatePurchase(AddPurchaseDTO PurchaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseDTO>> GetAllPurchases()
        {
            var purchases = await _purchaseRepository.GetAllPurchases();
            return purchases.Select(p => p.ToPurchaseDto());
        }

        public async Task<PurchaseDTO> GetPurchaseById(int id)
        {
            var purchase = await _purchaseRepository.GetPurchaseById(id);
            return purchase?.ToPurchaseDto();
        }
    }
}