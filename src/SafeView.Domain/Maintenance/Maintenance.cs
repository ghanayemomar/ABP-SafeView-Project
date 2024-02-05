using SafeView.Orders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace SafeView.Maintenance
{
    public class Maintenance : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public DateTime OrderGuarantee { get; set; }

        public decimal Price { get; set; }

        public DateTime MaintenanceDate { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
