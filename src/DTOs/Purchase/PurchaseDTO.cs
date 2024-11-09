using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;
using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.DTOs.Purchase
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<ProductDTO> ProductList { get; set; } = new List<ProductDTO>();
        public List<int> Quantities { get; set; } = new List<int>();
        public int TotalPrice { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Commune { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int UserId { get; set; }
    }
}