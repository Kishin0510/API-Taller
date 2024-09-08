using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Type { get; set; }
        public int ?Price { get; set; }
        public string ?ImageUrl { get; set; }

    }
}