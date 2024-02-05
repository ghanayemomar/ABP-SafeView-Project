using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Dashboard;
using SafeView.Interface;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DashboardController : AbpController, IDashboardService
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<OrderDashboardDto> GetOrderStatusCountsAsync()
        {
            return await _dashboardService.GetOrderStatusCountsAsync();
        }

        [HttpGet]
        public async Task<ProductDashboardDto> GetProductsCountAsync()
        {
            return await _dashboardService.GetProductsCountAsync();
        }
        [HttpGet]
        public async Task<CustomerDashboardDto> GetCustomersCountAsync()
        {
            return await _dashboardService.GetCustomersCountAsync();
        }

        [HttpGet]   
        public async Task<MaintenanceDashboardDto> GetMaintenancesCountAsync()
        {
            return await _dashboardService.GetMaintenancesCountAsync();
        }
    }
}
