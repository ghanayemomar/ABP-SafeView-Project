using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Products
{
    public static class ProductValidationConstants
    {
        public const string InputCannotBeNull = "Input is invalid.";
        public const string NameCannotBeNullOrEmpty = "Name is invalid.";
        public const string PriceCannotBeNullOrZero = "Price is invalid.";
    }

    public class ProductManager : DomainService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        public ProductManager(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        private void ValidateProduct(Product inputFromUser)
        {
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), ProductValidationConstants.InputCannotBeNull);
            }
            if (string.IsNullOrWhiteSpace(inputFromUser.Name))
            {
                throw new BusinessException(nameof(inputFromUser), ProductValidationConstants.NameCannotBeNullOrEmpty);
            }
            if (inputFromUser.PriceForMe <= 0 || inputFromUser.PriceForSell <= 0)
            {
                throw new BusinessException(nameof(inputFromUser), ProductValidationConstants.PriceCannotBeNullOrZero);
            }
        }

        public async Task<Product> CreateAsync(Product inputFromUser)
        {
            ValidateProduct(inputFromUser);
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
            ValidateProduct(inputFromUser);
            return await _productRepository.UpdateAsync(inputFromUser);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<Product>> GetListByIdsAsync(List<Guid> productIds)
        {
            var products = (await _productRepository.GetQueryableAsync())
                .Where(p => productIds.Contains(p.Id));

            return products;
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await _productRepository.CountAsync();
        }

    }
}
