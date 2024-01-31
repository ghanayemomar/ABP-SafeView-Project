using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
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
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), "Input cannot be null.");
            }

            GuidGenerator.Create();
            return await _productRepository.InsertAsync(inputFromUser);
        }


        public async Task<List<Product>> GetAllAsync()
        {
            var result = await _productRepository.GetListAsync();

            if (result == null)
            {

                throw new DllNotFoundException();
            }

            return result;

        }



        public async Task<Product> GetByIdAsync(Guid id)
        {
            var result = await _productRepository.GetAsync(id);

            if (result == null)

            {
                throw new DllNotFoundException();
            }
            return result;
        }


        public async Task<Product> UpdateAsync(Product inputFromUser)
        {
            if (inputFromUser == null)
            {
                throw new ArgumentNullException(nameof(inputFromUser), "Input cannot be null.");
            }

            return await _productRepository.UpdateAsync(inputFromUser);
        }


        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

    }
}
