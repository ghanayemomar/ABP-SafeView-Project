using SafeView.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Maintenance
{
    public static class MaintenanceValidationConstatns
    {
        public static string InvalidInput = "Input is invalid.";
        public static string InvalidOrderGuarantee = "Order Guarantee is invalid.";
        public const string InvalidPrice = "Price is invalid.";
        public const string InvalidMainDate = "Maintenance date is invalid.";
        public const string InvalidOrderId = "Order id is invalid.";
    }

    public class MaintenanceManager : DomainService

    {
        private readonly IRepository<Maintenance, Guid> _maintenanceRepository;
        private readonly OrderManager _orderManager;

        public MaintenanceManager(IRepository<Maintenance, Guid> maintenanceRepository, OrderManager orderManger)
        {
            _maintenanceRepository = maintenanceRepository;
            _orderManager = orderManger;
        }

        private async Task MaintenanceValidation(Maintenance inputFromUser)
        {
            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), MaintenanceValidationConstatns.InvalidInput);
            }

            if (inputFromUser.OrderGuarantee == default(DateTime))
            {
                throw new BusinessException(nameof(inputFromUser), MaintenanceValidationConstatns.InvalidOrderGuarantee);
            }

            if (inputFromUser.Price <= 0)
            {
                throw new BusinessException(nameof(inputFromUser), MaintenanceValidationConstatns.InvalidPrice);
            }

            if (inputFromUser.MaintenanceDate == default(DateTime))
            {
                throw new BusinessException(nameof(inputFromUser), MaintenanceValidationConstatns.InvalidMainDate);
            }

            var order = await _orderManager.GetByIdAsync(inputFromUser.OrderId);
            if (order == null)
            {
                throw new BusinessException(nameof(inputFromUser), MaintenanceValidationConstatns.InvalidOrderId);
            }

        }

        public async Task<Maintenance> CreateAsync(Maintenance inputFromUser)
        {
            MaintenanceValidation(inputFromUser);
            GuidGenerator.Create();
            return await _maintenanceRepository.InsertAsync(inputFromUser);
        }

        public async Task<Maintenance> UpdateAsync(Maintenance inputFromUser)
        {
            MaintenanceValidation(inputFromUser);
            return await _maintenanceRepository.UpdateAsync(inputFromUser);
        }

        public async Task<List<Maintenance>> GetAllAsync()
        {
            return await _maintenanceRepository.GetListAsync();
        }

        public async Task<Maintenance> GetByIdAsync(Guid id)
        {
            return await _maintenanceRepository.GetAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _maintenanceRepository.DeleteAsync(id);
        }
        public async Task<int> GetMaintenancesCountAsync()
        {
            return await _maintenanceRepository.CountAsync();
        }
    }
}
