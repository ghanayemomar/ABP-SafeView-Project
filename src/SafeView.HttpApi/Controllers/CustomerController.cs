using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Customer;
using SafeView.Dto.Order;
using SafeView.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : AbpController
    {
        //why you are not inheritance from ICustomerService
        private readonly  ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }

        [HttpPost]
        public async Task CreateCustomer([FromBody] CreateCustomerDto customer)
        {
            await _customerService.CreateAsync(customer);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveAllCustomers()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveCustomerById(Guid id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        public async Task UpdateCustomer([FromBody] UpdateCustomerDto customer)
        {
            await _customerService.UpdateAsync(customer);
        }
    }
}
