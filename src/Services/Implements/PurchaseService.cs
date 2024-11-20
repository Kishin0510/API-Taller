using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Purchase;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Mappers;
using Api_Taller.src.Repositories;
using Api_Taller.src.Models;

namespace Api_Taller.src.Services.Implements
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
       public async Task<bool> CreatePurchase(AddPurchaseDTO AddPurchaseDTO, int userId)
        {
            var purchase = AddPurchaseDTO.ToPurchaseModel();
            int totalPrice = 0;
            var products = await _productRepository.GetProducts();
            List<PurchaseProduct> productList = new List<PurchaseProduct>();
            for (int i = 0; i< AddPurchaseDTO.ProductIds.Count; i++)
            {
                var productId = AddPurchaseDTO.ProductIds[i];
                var quantity = AddPurchaseDTO.Quantities[i];
                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    totalPrice += product.Price * quantity;
                    productList.Add(new PurchaseProduct
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Product = product,
                        Purchase = purchase,
                        PurchaseId = purchase.Id
                    });
                }
            }
        
            purchase.TotalPrice = totalPrice;
            var user = await _userRepository.GetUserById(userId);
            if (user != null)
            {
                purchase.User = user;
                purchase.UserId = user.Id;
                purchase.PurchaseProducts = productList;
                return await _purchaseRepository.CreatePurchase(purchase);
            }
            return false;
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