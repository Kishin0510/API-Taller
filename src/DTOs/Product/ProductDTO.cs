using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.DTOs.Product
{
    public class ProductDTO
    {
        /// <summary>
        /// Id del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public int Price { get; set; } = 0;

        /// <summary>
        /// Stock del producto.
        /// </summary>
        public int Stock { get; set; } = 0;

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string ImgURL { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto.
        /// </summary>
        public string ProductType { get; set; } = string.Empty;
    }
}