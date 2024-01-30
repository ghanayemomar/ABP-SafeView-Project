using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Product;
using SafeView.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : AbpController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task CreateProduct([FromBody] CreateProductDto product)
        {
            await _productService.CreateAsync(product);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveAllProducts()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveProdcutById(Guid id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        public async Task UpdateProduct([FromBody] UpdateProductDto product)
        {
            await _productService.UpdateAsync(product);
        }
    }
}
