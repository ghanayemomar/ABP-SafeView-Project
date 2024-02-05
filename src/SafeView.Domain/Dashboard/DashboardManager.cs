using SafeView.Customers;
using SafeView.Maintenance;
using SafeView.Orders;
using SafeView.Products;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SafeView.Dashboard
{
    public class DashboardManager : DomainService
    {
        private readonly ProductManager _productManager;
        private readonly OrderManager _orderManager;
        private readonly CustomerManager _customerManager;
        private readonly MaintenanceManager _mainteneceManager;

        public DashboardManager(ProductManager productManager, OrderManager orderManager, CustomerManager customerManager , MaintenanceManager maintenanceManager)
        {
            _productManager = productManager;
            _orderManager = orderManager;
            _customerManager = customerManager;
            _mainteneceManager = maintenanceManager;
        }

        public async Task<OrderDashboard> GetOrderStatusCountAsync()
        {
            return await _orderManager.GetOrderStatusCount();
        }

        public async Task<ProductDashboard> GetProductsCount()
        {
            var products = await _productManager.GetProductsCountAsync();
            var productDasboard = new ProductDashboard
            {
                ProductCount = products
            };
            return productDasboard;
        }

        public async Task<CustomerDashboard> GetCustomerCount()
        {
            var customerCount = await _customerManager.GetCustomersCountAsync();
            var customerDashboard = new CustomerDashboard
            {
                CustomerCount = customerCount
            };
            return customerDashboard;
        }
        public async Task<MaintenanceDashboard> GetMaintenanceCount()
        {
            var maintenanceCount = await _mainteneceManager.GetMaintenancesCountAsync();
            var maintenanceDashboard = new MaintenanceDashboard
            {
                MaintenanceCount = maintenanceCount
            };
            return maintenanceDashboard;
        }
    }
}