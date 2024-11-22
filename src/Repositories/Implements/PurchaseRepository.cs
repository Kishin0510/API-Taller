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
        private readonly IProductRepository _productRepository;
        public PurchaseRepository(ApplicationDBContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<bool> CreatePurchase(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await _context.Purchases.Include(p => p.User).Include(p => p.PurchaseProducts).ThenInclude(pp => pp.Product).ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseById(int id)
        {
            return await _context.Purchases
            .Include(p => p.User)
            .Include(p => p.PurchaseProducts)
            .ThenInclude(pp => pp.Product)
            .Where(p => p.UserId == id)
            .OrderBy(p => p.PurchaseDate)
            .ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> SearchPurchases(string? nameQuery, string? dateQuery)
        {
            var purchases = await _context.Purchases.Include(p => p.User).Include(p => p.PurchaseProducts).ThenInclude(pp => pp.Product).ToListAsync();

            if (!string.IsNullOrEmpty(nameQuery))
            {
                purchases = purchases.Where(p => p.User.Name.Contains(nameQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(dateQuery))
            {
                purchases = purchases.Where(p => p.PurchaseDate.ToString().Contains(dateQuery)).ToList();
            }
            purchases = purchases.OrderBy(p => p.PurchaseDate).ToList();

            return purchases;
        }
    }
}