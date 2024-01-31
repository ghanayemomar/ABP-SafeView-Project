using Microsoft.AspNetCore.Mvc;
using SafeView.Dto.Maintenance;
using SafeView.Dto.Product;
using SafeView.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MaintenanceController : AbpController
    {
        private readonly IMaintenaceService _maintenanceService;

        public MaintenanceController(IMaintenaceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }


        [HttpPost]
        public async Task CreateMaintenance([FromBody] CreateMaintenanceDto maintenance)
        {
            await _maintenanceService.CreateAsync(maintenance);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveAllMaintenance()
        {
            var result = await _maintenanceService.GetListAsync();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> RetriveMaintenanceById(Guid id)
        {
            var result = await _maintenanceService.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMaintenance(Guid id)
        {
            await _maintenanceService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        public async Task UpdateMaintenance([FromBody] UpdateMaintenanceDto maintenance)
        {
            await _maintenanceService.UpdateAsync(maintenance);
        }
    }
}
