using SafeView.Dto.Dashboard;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface IDashboardService : IApplicationService
    {
        Task<OrderDashboardDto> GetOrderStatusCountsAsync();
        Task<ProductDashboardDto> GetProductsCountAsync();

        Task<CustomerDashboardDto> GetCustomersCountAsync();

        Task<MaintenanceDashboardDto> GetMaintenancesCountAsync();
    }
}
