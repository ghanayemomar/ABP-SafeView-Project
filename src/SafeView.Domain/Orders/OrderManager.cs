using SafeView.Dashboard;
using SafeView.Enums;
using SafeView.OrderProducts;
using SafeView.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Orders
{

    public static class OrderValidationConstants
    {
        public const string InputCannotBeNull = "Input is invalid.";
        public const string NameCannotBeNullOrEmpty = "Name is invalid.";
        public const string PriceCannotBeNullOrZero = "Price is invalid.";
        public const string StatusInvalidValue = "Status is invalid.";
        public const string ProductIdInvlidValueOrNull = "ProductId is invalid";
        public const string CustomerIdInvalidvalueOrNull = "OrderId is invalid";
    }

    public class OrderManager : DomainService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<OrderProduct, Guid> _orderProductRepository;
        private readonly ProductManager _productManager;

        public OrderManager(IRepository<Order, Guid> productRepository, IRepository<OrderProduct, Guid> orderProductRepository, ProductManager productManager)
        {
            _orderRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _productManager = productManager;
        }

        private async Task<decimal> CalculateTotalOrderPrice(List<Guid> productsIds)
        {
            var products = await _productManager.GetListByIdsAsync(productsIds);
            return products.Sum(product => product.PriceForSell);
        }

        private async void ValidateOrders(Order inputFromUser)
        {
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), OrderValidationConstants.InputCannotBeNull);
            }
            if (string.IsNullOrEmpty(inputFromUser.Name))
            {
                throw new BusinessException(nameof(inputFromUser), OrderValidationConstants.NameCannotBeNullOrEmpty);
            }
            if (inputFromUser.OrderProducts == null || !inputFromUser.OrderProducts.Any())
            {
                throw new BusinessException(nameof(inputFromUser), OrderValidationConstants.ProductIdInvlidValueOrNull);
            }
            if (inputFromUser.CustomerId == null)
            {
                throw new BusinessException(nameof(inputFromUser), OrderValidationConstants.CustomerIdInvalidvalueOrNull);
            }
        }

        public async Task<Order> CreateAsync(Order inputFromUser)
        {
            ValidateOrders(inputFromUser);

            if (inputFromUser.OrderProducts != null || inputFromUser.OrderProducts.Any())
            {
                await _orderProductRepository.InsertManyAsync(inputFromUser.OrderProducts);
                var productIds = inputFromUser.OrderProducts.Select(op => op.ProductId).ToList();
                inputFromUser.TotalOrderPrice = await CalculateTotalOrderPrice(productIds);
            }
            GuidGenerator.Create();
            return await _orderRepository.InsertAsync(inputFromUser, true);
        }

        public async Task<Order> UpdateAsync(Order inputFromUser)
        {
            ValidateOrders(inputFromUser);
            return await _orderRepository.UpdateAsync(inputFromUser, true);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var result = (await _orderProductRepository.GetQueryableAsync());
            return await _orderRepository.GetListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _orderRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<int> GetOrdersCountAsync()
        {
            return await _orderRepository.CountAsync();
        }

        public async Task<OrderDashboard> GetOrderStatusCount()
        {
            var pendingOrderCount = await _orderRepository.CountAsync(order => order.Status == OrderStatus.Pending);
            var acceptedOrderCount = await _orderRepository.CountAsync(order => order.Status == OrderStatus.Accepted);
            var rejectedOrderCount = await _orderRepository.CountAsync(order => order.Status == OrderStatus.Rejected);
            var ordersCount = await _orderRepository.CountAsync();
            return new OrderDashboard
            {
                PedningOrdersCount = pendingOrderCount,
                AcceptedOrdersCount = acceptedOrderCount,
                RejectedOrdersCount = rejectedOrderCount,
                OrdersCount = ordersCount
            };
        }

    }
}
