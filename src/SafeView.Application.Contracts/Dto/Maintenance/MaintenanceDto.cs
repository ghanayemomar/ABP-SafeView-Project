using System;

namespace SafeView.Dto.Maintenance
{
    public class MaintenanceDto
    {
        public DateTime OrderGuarantee { get; set; }
        public decimal Price { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public Guid OrderId { get; set; }
    }
}
