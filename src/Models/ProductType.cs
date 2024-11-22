using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class ProductType
    {
        /// <summary>
        /// Id del tipo de producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tipo de producto.
        /// </summary>
        public string Type { get; set; } = null!;
    }
}