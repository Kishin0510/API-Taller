using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.Cart
{
    public class CartCookiesDto
    {
         public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
}