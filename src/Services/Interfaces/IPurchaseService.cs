using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Purchase;

namespace Api_Taller.src.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseDTO>> GetAllPurchases();
        Task<int> CreatePurchase(AddPurchaseDTO PurchaseDTO);
        Task<PurchaseDTO> GetPurchaseById(int id);
    }
}