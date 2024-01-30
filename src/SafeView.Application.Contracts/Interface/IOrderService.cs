using SafeView.Dto.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface IOrderService : IApplicationService
    {
        Task<OrderDto> CreateAsync(CreateOrderDto inputFromUser);

        Task<OrderDto> GetByIdAsync(Guid id);

        Task<List<OrderDto>> GetListAsync();

        Task<OrderDto> UpdateAsync(UpdateOrderDto inputFromUser);

        Task DeleteAsync(Guid id);
    }
}
