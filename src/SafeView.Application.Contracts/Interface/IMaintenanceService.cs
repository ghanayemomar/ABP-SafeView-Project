using SafeView.Dto.Maintenance;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface IMaintenaceService: IApplicationService
    {
        Task<CreateMaintenanceDto> CreateAsync(CreateMaintenanceDto inputFromUser);

        Task<MaintenanceDto> GetByIdAsync(int id);

        Task<List<MaintenanceDto>> GetListAsync();

        Task<UpdateMaintenanceDto> UpdateAsync(UpdateMaintenanceDto inputFromUser);

        Task<bool> DeleteAsync(int id);
    }
}
