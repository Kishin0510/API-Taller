using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Cart;
using Api_Taller.src.Models;

namespace Api_Taller.src.Mappers
{
    public static class CartMapper
    {
        public static CartDto ToCartDTO(this Cart cartModel)
        {
            return new CartDto
            {
                CartId = cartModel.CartId,
                UserId = cartModel.UserId,
                CartItems = cartModel.CartItems.Select(ci => ci.ToCartItemDTO()).ToList()
            };
        }
        public static CartItemDto ToCartItemDTO(this CartItem cartItemModel)
        {
            return new CartItemDto
            {
                ProductId = cartItemModel.ProductId,
                Quantity = cartItemModel.Quantity,
            };
        }
    }
}