using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
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
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), "Input cannot be null.");
            }


            if (inputFromUser.Price == 0 || inputFromUser.Price == null)
            {
                throw new BusinessException(nameof(inputFromUser), "Price cannot be null or zero.");
            }


            GuidGenerator.Create();
            return await _maintenanceRepository.InsertAsync(inputFromUser);
        }

        public async Task<List<Maintenance>> GetAllAsync()
        {
            return await _maintenanceRepository.GetListAsync();
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
