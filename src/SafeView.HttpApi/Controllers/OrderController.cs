using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Order;
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
    public class OrderController : AbpController,IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }


        [HttpPost]
        public async Task<OrderDto> CreateAsync(CreateOrderDto inputFromUser)
        {
            var test = inputFromUser;
            return await _orderService.CreateAsync(inputFromUser);
        }


        [HttpGet]
        public async Task<List<OrderDto>> GetListAsync()
        {
            return await _orderService.GetListAsync();
        }


        [HttpGet]
        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            return await _orderService.GetByIdAsync(id);
        }


        [HttpPut]
        public async Task<OrderDto> UpdateAsync(UpdateOrderDto inputFromUser)
        {
            return await _orderService.UpdateAsync(inputFromUser);
        }


        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _orderService.DeleteAsync(id);
        }
    }
}
