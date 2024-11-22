using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Product
    {
        /// <summary>
        /// Id del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public int Price { get; set; } = 0;

        /// <summary>
        /// Stock del producto.
        /// </summary>
        public int Stock { get; set; } = 0;

        /// <summary>
        /// La URL de la imagen del producto.
        /// </summary>
        public string ?ImageUrl { get; set; }

        /// <summary>
        /// Id de la imagen del producto.
        /// </summary>
        public string ?ImageId { get; set;}

        /// Entity Framework Relations
        ///
        /// <summary>
        /// Id del tipo de producto. 
        /// </summary>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Tipo de producto.
        /// </summary>
        public ProductType ProductType { get; set; } = null!;

        /// <summary>
        /// Lista de compras de un producto.
        /// </summary>
        public List<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
    }
}