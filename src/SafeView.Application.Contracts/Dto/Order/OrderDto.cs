﻿using SafeView.Dto.Customer;
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
        public OrderStatus Status { get; set; }
        public DateTime OrderGuarantee { get; set; } = DateTime.Now.AddYears(1);
        public ICollection<OrderProductDto> OrderProducts { get; set; }
        public CustomerDto Customer { get; set; }
    }
}