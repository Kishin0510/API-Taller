using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public string ImgURL { get; set; } = string.Empty;
        public ProductType ProductType { get; set; } = null!;
    }
}