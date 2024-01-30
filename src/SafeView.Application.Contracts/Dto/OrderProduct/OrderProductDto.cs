using SafeView.Dto.Order;
using SafeView.Dto.Product;
using System;

namespace SafeView.Dto.OrderProduct
{
    public class OrderProductDto
    {
        public Guid OrderId { get; set; }
        public OrderDto Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
