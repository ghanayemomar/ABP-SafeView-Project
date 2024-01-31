using System;
using System.ComponentModel.DataAnnotations;

namespace SafeView.Dto.Maintenance
{
    public class CreateMaintenanceDto
    {
        [Required]
        public DateTime OrderGuarantee { get; set; }
        public decimal Price { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public Guid OrderId { get; set; }
    }
}
