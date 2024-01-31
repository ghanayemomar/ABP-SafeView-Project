using SafeView.Customers;
using SafeView.Dto.Customer;
using SafeView.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.CustomerService
{
    public class CustomerService : ApplicationService, ICustomerService
    {
        private readonly CustomerManager _customerManager;

        public CustomerService(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }



        public async Task<CustomerDto> CreateAsync(CreateCustomerDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<CreateCustomerDto, Customer>(inputFromUser);

            var managerResult = await _customerManager.CreateAsync(mapping);

            var finalResult = ObjectMapper.Map<Customer, CustomerDto>(managerResult);

            return finalResult;
        }



        public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto inputFromUser)
        {
            var itemFromDatabase = await _customerManager.GetByIdAsync(inputFromUser.Id); 

            var mapping = ObjectMapper.Map(inputFromUser,itemFromDatabase);

            var managerResult = await _customerManager.UpdateAsync(mapping);

            var finalResult = ObjectMapper.Map<Customer, CustomerDto>(managerResult);

            return finalResult;
        }



        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var managerResult = await _customerManager.GetAllAsync();

            var finalResult = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(managerResult);

            return finalResult;
        }



        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var managerResult = await _customerManager.GetByIdAsync(id);

            var finalResult = ObjectMapper.Map<Customer, CustomerDto>(managerResult);

            return finalResult;
        }



        public async Task DeleteAsync(Guid id)
        {
            await _customerManager.DeleteAsync(id);
        }

    }
}
