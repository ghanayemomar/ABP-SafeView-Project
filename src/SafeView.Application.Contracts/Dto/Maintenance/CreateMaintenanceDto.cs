using SafeView.Dto.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeView.Dto.Maintenance
{
    public class CreateMaintenanceDto
    {
        [Required]
        public DateTime OrderGuarantee { get; set; }
        public decimal Price { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public OrderDto Order { get; set; }
    }
}
