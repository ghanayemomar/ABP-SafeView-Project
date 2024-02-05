using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace SafeView.OrderProducts
{
    public class OrderProduct : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        [ForeignKey(nameof(SafeView.Orders.Order))]
        public Guid OrderId { get; set; }
        //public SafeView.Orders.Order Order { get; set; }

        [Required]
        [ForeignKey(nameof(SafeView.Products.Product))]
        public Guid ProductId { get; set; }
        //public SafeView.Products.Product Product { get; set; }
    }
}
