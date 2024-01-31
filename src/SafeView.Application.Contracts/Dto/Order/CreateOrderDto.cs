using SafeView.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafeView.Dto.Order
{
    public class CreateOrderDto
    {
        public string Name { get; set; }
        
        public decimal TotalOrderPrice { get; set; }
        
        public decimal PayedTotalOrderPrice { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public DateTime OrderGuarantee { get; set; } = DateTime.Now.AddYears(1);

        [Required]
        public List<Guid> ProductIds {  get; set; }

        [Required]
        public Guid CustomerId { get; set; }    
    }
}
