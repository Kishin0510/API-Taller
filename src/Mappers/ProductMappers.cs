using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.DTOs.Product;
using Api_Taller.src.Models;
using Api_Taller.src.Repositories.Interfaces;

namespace Api_Taller.src.Mappers
{
    public static class ProductMappers
    {
        public static ProductDTO ToProductDTO(this Product productModel)
        {
            return new ProductDTO
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price,
                Stock = productModel.Stock,
                ImgURL = productModel.ImageUrl ?? string.Empty,
                ProductType = productModel.ProductType?.Type ?? string.Empty
            };
        }

        public static Product ToProductModel(this AddProductDTO addProductDTO)
        {
            return new Product
            {
                Name = addProductDTO.Name,
                Price = addProductDTO.Price,
                Stock = addProductDTO.Stock,
                ProductTypeId = addProductDTO.ProductTypeId
            };
        }
    }
}