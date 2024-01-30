using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Order;
using SafeView.Dto.Product;
using SafeView.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : AbpController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        [HttpPost]
        public async Task CreateOrder([FromBody] CreateOrderDto order)
        {
            await _orderService.CreateAsync(order);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveAllOrders()
        {
            var result = await _orderService.GetListAsync();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveOrderById(Guid id)
        {
            var result = await _orderService.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        public async Task UpdateOrder([FromBody] UpdateOrderDto order)
        {
            await _orderService.UpdateAsync(order);
        }
    }
}
