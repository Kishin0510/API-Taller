using Api_Taller.src.Models;
using Api_Taller.src.Mappers;
using Api_Taller.src.Services.Interfaces;
using Api_Taller.src.Repositories.Interfaces;
using Api_Taller.src.DTOs.Product;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Api_Taller.src.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly Cloudinary _cloudinary;

        public ProductService(IProductRepository productRepository, IProductTypeRepository productTypeRepository, Cloudinary cloudinary)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _cloudinary = cloudinary;
        }

        public async Task<bool> AddProduct(AddProductDTO addProductDTO)
        {
            if (!_productTypeRepository.ValidProductType(addProductDTO.ProductTypeId).Result) 
            {
                throw new Exception("Tipo de producto no válido");
            }
            if (_productRepository.ValidProductByNameAndType(addProductDTO.Name, addProductDTO.ProductTypeId).Result)
            {
                throw new Exception("Un producto con el mismo nombre y tipo ya existe");
            }
            if(addProductDTO.Image == null)
            {
                throw new Exception("Imagen requerida");
            }
            if(addProductDTO.Image.ContentType != "image/png" && addProductDTO.Image.ContentType != "image/jpeg")
            {
                throw new Exception("Formato de imagen no válido");
            }
            if(addProductDTO.Image.Length > 10 * 1024 * 1024) 
            {
                throw new Exception("Tamaño de imagen no válido, debe pesar menos de 10MB");
            }
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(addProductDTO.Image.FileName, addProductDTO.Image.OpenReadStream()),
                Folder = "products_images"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if(uploadResult.Error != null)
            {
                throw new Exception("Error al subir la imagen");
            }
            var newProduct = addProductDTO.ToProductModel();
            var productType = await _productTypeRepository.GetProductType(addProductDTO.ProductTypeId);
            newProduct.ProductType = productType;
            newProduct.ImageUrl = uploadResult.SecureUrl.AbsoluteUri;
            newProduct.ImageId = uploadResult.PublicId;

            var addResult = await _productRepository.AddProduct(newProduct);
            return addResult;
            


        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditProduct(int id, EditProductDTO editProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAvailableProducts(int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productDTOs = products.Select(async p => 
            {
                p.ProductType = await _productTypeRepository.GetProductType(p.ProductTypeId);
                return p.ToProductDTO();
            }).ToList();

            return await Task.WhenAll(productDTOs);

        }

        public Task<IEnumerable<ProductDTO>> SearchAvailableProducts(string query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> SearchProducts(string query)
        {
            throw new NotImplementedException();
        }
    }
}