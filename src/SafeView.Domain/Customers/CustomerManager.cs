using SafeView.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            GuidGenerator.Create();

            return await _customerRepository.InsertAsync(inputFromUser);
        }


        public async Task<Customer> UpdateAsync(Customer inputFromUser)
        {
            return await _customerRepository.UpdateAsync(inputFromUser);
        }


        public async Task<ICollection<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetListAsync();
        }


        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _customerRepository.GetAsync(id);
        }
        

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
