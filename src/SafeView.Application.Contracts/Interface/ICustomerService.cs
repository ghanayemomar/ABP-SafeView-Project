using SafeView.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface ICustomerService : IApplicationService
    {
        Task<CustomerDto> CreateAsync(CreateCustomerDto inputFromUser);

        Task<CustomerDto> UpdateAsync(UpdateCustomerDto inputFromUser);

        Task<List<CustomerDto>> GetAllAsync();

        Task<CustomerDto> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
