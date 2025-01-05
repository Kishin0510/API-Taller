using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Cart;
using Api_Taller.src.Models;

namespace Api_Taller.src.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetCartByUserId(int? userId = null);
        Task AddItemCart(CartItemDto cartItemDto, int? userId);
        Task sumItemCart(int cartId, int productId);
        Task substractItemCart(int cartId, int productId);
        Task DeleteCart(int cartId);
        
    }
}