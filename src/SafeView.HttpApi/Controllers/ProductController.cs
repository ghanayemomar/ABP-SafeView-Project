using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Product;
using SafeView.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : AbpController, IProductService
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ProductDto> CreateAsync(CreateProductDto inputFromUser)
        {
            return await _productService.CreateAsync(inputFromUser);
        }


        [HttpPut]
        public async Task<ProductDto> UpdateAsync(UpdateProductDto inputFromUser)
        {
            return await _productService.UpdateAsync(inputFromUser);
        }


        [HttpGet]
        public async Task<List<ProductDto>> GetAllAsync()
        {
             return await _productService.GetAllAsync();

        }


        [HttpGet]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return await _productService.GetByIdAsync(id);
        }


        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _productService.DeleteAsync(id);

        }
    }
}
