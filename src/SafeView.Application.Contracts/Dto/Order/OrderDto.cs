using SafeView.Dto.OrderProduct;
using SafeView.Enums;
using System;
using System.Collections.Generic;

namespace SafeView.Dto.Order
{
    public class OrderDto
    {
        public string Name { get; set; }

        public decimal TotalOrderPrice { get; set; }

        public decimal PayedTotalOrderPrice { get; set; }

        public Guid Id { get; set; }    

        public OrderStatus Status { get; set; }

        public DateTime OrderGuarantee { get; set; } = DateTime.Now.AddYears(1);

        public List<OrderProductDto> OrderProducts { get; set; }

        public Guid CustomerId { get; set; }
    }
}
