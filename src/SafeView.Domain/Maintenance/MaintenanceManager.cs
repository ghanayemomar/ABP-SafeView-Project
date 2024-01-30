using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Maintenance
{
    public class MaintenanceManager : DomainService
    {
        private readonly IRepository<Maintenance, Guid> _maintenanceRepository;
        public MaintenanceManager(IRepository<Maintenance, Guid> maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }
        public async Task<Maintenance> CreateAsync(Maintenance inputFromUser)
        {
            GuidGenerator.Create();
            return await _maintenanceRepository.InsertAsync(inputFromUser);
        }
        public async Task<Maintenance> GetByIdAsync(Guid id)
        {
            return await _maintenanceRepository.GetAsync(id);
        }
        public async Task<Maintenance> UpdateAsync(Maintenance inputFromUser)
        {
            return await _maintenanceRepository.UpdateAsync(inputFromUser);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _maintenanceRepository.DeleteAsync(id);
        }
    }
}
