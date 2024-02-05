using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Maintenance;
using SafeView.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MaintenanceController : AbpController, IMaintenaceService
    {
        private readonly IMaintenaceService _maintenanceService;

        public MaintenanceController(IMaintenaceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }


        [HttpPost]
        public async Task<MaintenanceDto> CreateAsync(CreateMaintenanceDto inputFromUser)
        {
            return await _maintenanceService.CreateAsync(inputFromUser);
        }


        [HttpPut]
        public async Task<MaintenanceDto> UpdateAsync(UpdateMaintenanceDto inputFromUser)
        {
            return await _maintenanceService.UpdateAsync(inputFromUser);
        }

        [HttpGet]
        public async Task<MaintenanceDto> GetByIdAsync(Guid id)
        {
            return await _maintenanceService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<MaintenanceDto>> GetListAsync()
        {
            return await _maintenanceService.GetListAsync();
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _maintenanceService.DeleteAsync(id);
        }

    }
}
