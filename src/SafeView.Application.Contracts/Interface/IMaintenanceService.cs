using SafeView.Dto.Maintenance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface IMaintenaceService : IApplicationService
    {
        Task<MaintenanceDto> CreateAsync(CreateMaintenanceDto inputFromUser);

        Task<MaintenanceDto> UpdateAsync(UpdateMaintenanceDto inputFromUser);

        Task<List<MaintenanceDto>> GetListAsync();

        Task<MaintenanceDto> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
