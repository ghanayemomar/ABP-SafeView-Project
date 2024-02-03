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
        private readonly OrderManager _orderManager;

        public OrderService(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        // why you are added more space here 


        public async Task<OrderDto> CreateAsync(CreateOrderDto inputFromUser)
        {
            var mapping = ObjectMapper.Map<CreateOrderDto, Order>(inputFromUser);

            var resultFromManager = await _orderManager.CreateAsync(mapping);

            var finalMapping = ObjectMapper.Map<Order, OrderDto>(resultFromManager);

            return finalMapping;
        }

        public async Task<OrderDto> UpdateAsync(UpdateOrderDto inputFromUser)
        {
            var itemFromDatabase = await _orderManager.GetByIdAsync(inputFromUser.Id);

            var mapping = ObjectMapper.Map(inputFromUser, itemFromDatabase);

            var managerResult = await _orderManager.UpdateAsync(mapping);

            var finalResult = ObjectMapper.Map<Order, OrderDto>(managerResult);

            return finalResult;
        }

        public async Task<List<OrderDto>> GetListAsync()
        {
            var managerResult = await _orderManager.GetAllAsync();

            var finalResult = ObjectMapper.Map<List<Order>, List<OrderDto>>(managerResult);

            return finalResult;
        }


        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var managerResult = await _orderManager.GetByIdAsync(id);

            var finalResult = ObjectMapper.Map<Order, OrderDto>(managerResult);

            return finalResult;

        }
        // why you are added more space here 


        public async Task DeleteAsync(Guid id)
        {
            await _orderManager.DeleteAsync(id);
        }


    }
}
