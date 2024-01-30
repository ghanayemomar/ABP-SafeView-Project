using SafeView.Dto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SafeView.Interface
{
    public interface IProductService : IApplicationService
    {
        Task<ProductDto> CreateAsync(CreateProductDto inputFromUser);

        Task<ProductDto> UpdateAsync(UpdateProductDto inputFromUser);

        Task<ICollection<ProductDto>> GetAllAsync();

        Task<ProductDto> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
