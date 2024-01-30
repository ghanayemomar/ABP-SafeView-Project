using SafeView.Dto.Product;
using SafeView.Interface;
using SafeView.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.ProductService
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly ProductManager _productManager;

        public ProductService(ProductManager productManager)
        {
            _productManager = productManager; 
        }


        public async Task<ProductDto> CreateAsync(CreateProductDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<CreateProductDto, Product>(inputFromUser);

            var managerResult = await _productManager.CreateAsync(mapping);

            var finalMapping = ObjectMapper.Map<Product, ProductDto>(managerResult);

            return finalMapping;
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<UpdateProductDto, Product>(inputFromUser);

            var managerResult = await _productManager.UpdateAsync(mapping);

            var finalResult = ObjectMapper.Map<Product, ProductDto>(managerResult);

            return finalResult;
        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var managerResult = await _productManager.GetAllAsync();

            var finalResult = ObjectMapper.Map<ICollection<Product>, ICollection<ProductDto>>(managerResult);

            return finalResult;
        }


        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var managerResult = await _productManager.GetByIdAsync(id);

            var finalResult = ObjectMapper.Map<Product, ProductDto>(managerResult);

            return finalResult;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productManager.DeleteAsync(id);
        }
    }
}
