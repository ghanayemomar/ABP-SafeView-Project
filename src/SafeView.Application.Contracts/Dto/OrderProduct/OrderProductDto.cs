using System;

namespace SafeView.Dto.OrderProduct
{
    public class OrderProductDto
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
