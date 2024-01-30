using System;

namespace SafeView.Dto.Product
{
    public class UpdateProductDto : CreateProductDto
    {
        public Guid Id { get; set; }
    }
}
