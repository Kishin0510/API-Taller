using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.DTOs.Product
{
    public class EditProductInfo
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
        public string? Image { get; set; }
        public string? ProductTypeId { get; set; }
        public string? ImageURL { get; set; }
        public string? ImageId { get; set; }
    }
}