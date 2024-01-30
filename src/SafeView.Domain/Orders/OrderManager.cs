using SafeView.OrderProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Orders
{
    public class OrderManager : DomainService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<OrderProduct, Guid> _orderProductRepository;


        public OrderManager(IRepository<Order, Guid> productRepository, IRepository<OrderProduct, Guid> orderProductRepository)
        {
            _orderRepository = productRepository;
            _orderProductRepository = orderProductRepository;
        }


        public async Task<Order> CreateAsync(Order inputFromUser)
        {
            GuidGenerator.Create();
            if (inputFromUser.OrderProducts != null || !inputFromUser.OrderProducts.Any())
            {
                await _orderProductRepository.InsertManyAsync(inputFromUser.OrderProducts);
            }
            return await _orderRepository.InsertAsync(inputFromUser);
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _orderRepository.GetListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return null;
            }
            return await _orderRepository.GetAsync(id);
        }

        public async Task<Order> UpdateAsync(Order inputFromUser)
        {
            if (inputFromUser == null)
            {
                return null;
            }
            return await _orderRepository.UpdateAsync(inputFromUser);
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id != null || id != Guid.Empty)
            {
                await _orderRepository.DeleteAsync(id);
            }
        }
    }
}
