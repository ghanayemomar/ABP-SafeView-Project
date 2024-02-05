using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Customer;
using SafeView.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : AbpController, ICustomerService
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }


        [HttpPost]
        public async Task<CustomerDto> CreateAsync(CreateCustomerDto inputFromUser)
        {
            return await _customerService.CreateAsync(inputFromUser);
        }

        [HttpPut]
        public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto inputFromUser)
        {
            return await _customerService.UpdateAsync(inputFromUser);
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAllAsync()
        {
            return await (_customerService.GetAllAsync());
        }


        [HttpGet]
        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            return await _customerService.GetByIdAsync(id);
        }



        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _customerService.DeleteAsync(id);
        }

    }
}
