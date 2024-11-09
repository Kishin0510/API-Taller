using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllPurchases();
        Task<bool> CreatePurchase(Purchase purchase);
        Task<Purchase?> GetPurchaseById(int id);
        
    }
}