using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Data;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller.src.Repositories.Implements
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddCart(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            await _context.CartItem.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart?> GetCart(int cartId)
        {
            var cart = await _context.Cart.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefaultAsync(c => c.CartId == cartId);
            return cart;
        }

        public async Task<Cart?> GetCartByUserId(int userId)
        {
            var cart = await _context.Cart.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefaultAsync(c => c.UserId == userId);
            return cart;
        }

        public async Task RemoveCart(int cartId)
        {
            var cart = await GetCart(cartId);
            if(cart != null)
            {
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCartItem(int cartItemId)
        {
            var cartItem = await _context.CartItem.FindAsync(cartItemId);
            if(cartItem != null)
            {
                _context.CartItem.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task updateCart(Cart cart)
        {
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            _context.CartItem.Update(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> hasItem (int cartId, int productId)
        {
            var cartItem = await _context.CartItem.FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
            if(cartItem == null)
            {
                return false;
            }
            return true;
        }
    }
}