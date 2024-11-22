using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public string ?ImageUrl { get; set; }
        public string ?ImageId { get; set;}

        // Entity Framework Relations
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;
        public List<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
    }
}