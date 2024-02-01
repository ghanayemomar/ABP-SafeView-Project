using SafeView.OrderProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
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
            if(inputFromUser.TotalOrderPrice == 0 || inputFromUser.PayedTotalOrderPrice == 0)
            {
                throw new BusinessException(nameof(inputFromUser), "Total order price or Payed total price cannot be 0.");
            }

            if (inputFromUser.OrderProducts != null || inputFromUser.OrderProducts.Any())
            {
                await _orderProductRepository.InsertManyAsync(inputFromUser.OrderProducts);
            }

            return await _orderRepository.InsertAsync(inputFromUser, true);
        }


        public async Task<Order> UpdateAsync(Order inputFromUser)
        {
            if (inputFromUser == null)
            {
                throw new ArgumentNullException(nameof(inputFromUser), "Input cannot be null.");
            }
            return await _orderRepository.UpdateAsync(inputFromUser,true);
        }


        public async Task<List<Order>> GetAllAsync()
        {
            //var result = (await _orderProductRepository.GetQueryableAsync()).Include(x => x.Cust).ToListAsync();
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

        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
