using System;

namespace SafeView.Dto.Order
{
    public class UpdateOrderDto : CreateOrderDto
    {
        public Guid Id { get; set; }
    }
}
