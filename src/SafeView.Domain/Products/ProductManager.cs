using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Products
{
    public class ProductManager : DomainService
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductManager(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateAsync(Product inputFromUser)
        {
            GuidGenerator.Create();

            return await _productRepository.InsertAsync(inputFromUser);
        }


        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _productRepository.GetListAsync();
        }


        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetAsync(id);
        }


        public async Task<Product> UpdateAsync(Product inputFromUser)
        {
            return await _productRepository.UpdateAsync(inputFromUser);
        }


        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

    }
}
