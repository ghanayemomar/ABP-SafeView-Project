using SafeView.Dto.Maintenance;
using SafeView.Interface;
using SafeView.Maintenance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.MaintenanceService
{
    public class MaintenanceService : ApplicationService, IMaintenaceService
    {
        private readonly MaintenanceManager _maintenanceManager;

        public MaintenanceService(MaintenanceManager maintenanceManager)
        {
            _maintenanceManager = maintenanceManager;
        }

        public async Task<MaintenanceDto> CreateAsync(CreateMaintenanceDto inputFromUser)
        {
            var mapper = ObjectMapper.Map<CreateMaintenanceDto, SafeView.Maintenance.Maintenance>(inputFromUser);

            var managerResult = await _maintenanceManager.CreateAsync(mapper);

            var finalResult = ObjectMapper.Map<SafeView.Maintenance.Maintenance, MaintenanceDto>(managerResult);

            return finalResult;
        }

        public async Task<MaintenanceDto> UpdateAsync(UpdateMaintenanceDto inputFromUser)
        {
            var itemFromDatabase = await _maintenanceManager.GetByIdAsync(inputFromUser.Id);

            var mapper = ObjectMapper.Map(inputFromUser, itemFromDatabase);

            var managerResult = await _maintenanceManager.UpdateAsync(mapper);

            var finalResult = ObjectMapper.Map<SafeView.Maintenance.Maintenance, MaintenanceDto>(managerResult);

            return finalResult;

        }

        public async Task<List<MaintenanceDto>> GetListAsync()
        {
            var managerResult = await _maintenanceManager.GetAllAsync();

            var finalResult = ObjectMapper.Map<List<SafeView.Maintenance.Maintenance>, List<MaintenanceDto>>(managerResult);

            return finalResult;
        }

        public async Task<MaintenanceDto> GetByIdAsync(Guid id)
        {
            var managerResult = await _maintenanceManager.GetByIdAsync(id);

            var finalResult = ObjectMapper.Map<SafeView.Maintenance.Maintenance, MaintenanceDto>(managerResult);

            return finalResult;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _maintenanceManager.DeleteAsync(id);
        }

    }
}
