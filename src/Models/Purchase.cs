using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<int> Quantities { get; set; } = new List<int>();
        public List<int> ProductList { get; set; } = new List<int>();
        public int TotalPrice { get; set; } = 0;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Commune { get; set; } = null!;
        public string Street { get; set; } = null!;

        // Entity Framework Relations
        public int UserId { get; set; }
        public User ?User { get; set; }
        
    }
}