using SafeView.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace SafeView.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal TotalOrderPrice { get; set; }

        [Required]
        public decimal PayedTotalOrderPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime OrderGuarantee { get; set; } = DateTime.Now.AddYears(1);

        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public SafeView.Customers.Customer Customer { get; set; }

        public ICollection<SafeView.Maintenance.Maintenance> Maintenances { get; set; }
        public ICollection<SafeView.OrderProducts.OrderProduct> OrderProducts { get; set; }

    }
}
