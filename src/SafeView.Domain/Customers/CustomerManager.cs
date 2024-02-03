using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Customers
{
    public class CustomerManager : DomainService
    {
        private readonly IRepository<Customer, Guid> _customerRepository;


        public CustomerManager(IRepository<Customer, Guid> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<Customer> CreateAsync(Customer inputFromUser)
        {
            if (inputFromUser == null)
                // why you added space here 
            {
                throw new BusinessException(nameof(inputFromUser), "Input cannot be null.");

            }

            if (string.IsNullOrWhiteSpace(inputFromUser.Name))
            {
                throw new BusinessException(nameof(inputFromUser.Name), "Name cannot be empty.");
            }

            GuidGenerator.Create();
            return await _customerRepository.InsertAsync(inputFromUser);
        }


        public async Task<Customer> UpdateAsync(Customer inputFromUser)
        {
            //why you added space here
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), "Input cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(inputFromUser.Name))
            {
                throw new BusinessException(nameof(inputFromUser.Name), "Name cannot be empty.");
            }

            return await _customerRepository.UpdateAsync(inputFromUser);
        }


        public async Task<List<Customer>> GetAllAsync()
        {
            var result = await _customerRepository.GetListAsync();
            // why you added space here 
            if (result == null)
            {
                throw new BusinessException(nameof(result), "Result is null.");
            }
            return result;
        }


        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var result = await _customerRepository.GetAsync(id);
           // why you added space here
            if (result == null)
            {
                throw new BusinessException(nameof(result), "Result is null.");
            }
           //need space here 
            return result;
        }


        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
