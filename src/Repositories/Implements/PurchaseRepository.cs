using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Data;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Api_Taller.src.Repositories.Implements
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDBContext _context;
        public PurchaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePurchase(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await _context.Purchases.Include(p => p.ProductList).Include(p => p.User).ToListAsync();
        }

        public Task<Purchase?> GetPurchaseById(int id)
        {
            return _context.Purchases.Include(p => p.ProductList).Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}