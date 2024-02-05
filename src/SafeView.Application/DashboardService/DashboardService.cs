using SafeView.Dashboard;
using SafeView.Dto.Dashboard;
using SafeView.Interface;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.DashboardService
{
    public class DashboardService : ApplicationService, IDashboardService
    {
        private readonly DashboardManager _dashboardManager;
        public DashboardService(DashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        public async Task<OrderDashboardDto> GetOrderStatusCountsAsync()
        {
            var managerResult = await _dashboardManager.GetOrderStatusCountAsync();
            var finalResult = ObjectMapper.Map<SafeView.Dashboard.OrderDashboard, OrderDashboardDto>(managerResult);
            return finalResult;
        }

        public async Task<ProductDashboardDto> GetProductsCountAsync()
        {
            var managerResult = await _dashboardManager.GetProductsCount();
            var finalResult = ObjectMapper.Map<SafeView.Dashboard.ProductDashboard, ProductDashboardDto>(managerResult);
            return finalResult;
        }
        public async Task<CustomerDashboardDto> GetCustomersCountAsync()
        {
            var managerResult = await _dashboardManager.GetCustomerCount();
            var finalResult = ObjectMapper.Map<SafeView.Dashboard.CustomerDashboard, CustomerDashboardDto>(managerResult);
            return finalResult;
        }

        public async Task<MaintenanceDashboardDto> GetMaintenancesCountAsync()
        {
            var managerResult = await _dashboardManager.GetMaintenanceCount();
            var finalResult = ObjectMapper.Map<MaintenanceDashboard, MaintenanceDashboardDto>(managerResult);
            return finalResult;
        }
    }
}
