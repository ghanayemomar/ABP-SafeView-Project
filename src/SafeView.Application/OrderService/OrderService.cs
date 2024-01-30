using SafeView.Dto.Order;
using SafeView.Interface;
using SafeView.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.OrderService
{
    public class OrderService : ApplicationService, IOrderService
    {
        private readonly OrderManager _productManager;

        public OrderService(OrderManager orderManager)
        {
            _productManager = orderManager;
        }


        public async Task<OrderDto> CreateAsync(CreateOrderDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<CreateOrderDto, Order>(inputFromUser);

            var resultFromManager = await _productManager.CreateAsync(mapping);

            var finalMapping = ObjectMapper.Map<Order, OrderDto>(resultFromManager);

            return finalMapping;
        }

        public async Task<OrderDto> UpdateAsync(UpdateOrderDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<UpdateOrderDto, Order>(inputFromUser);

            var managerResult = await _productManager.UpdateAsync(mapping);

            var finalResult = ObjectMapper.Map<Order, OrderDto>(managerResult);

            return finalResult;
        }

        public async Task<List<OrderDto>> GetListAsync()
        {
            var managerResult = await _productManager.GetAllAsync();

            var finalResult = ObjectMapper.Map<ICollection<Order>, List<OrderDto>>(managerResult);

            return finalResult;
        }


        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var managerResult = await _productManager.GetByIdAsync(id);

            var finalResult = ObjectMapper.Map<Order, OrderDto>(managerResult);

            return finalResult;

        }


        public async Task DeleteAsync(Guid id)
        {
            await _productManager.DeleteAsync(id);
        }


    }
}
