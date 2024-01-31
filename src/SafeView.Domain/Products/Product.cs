using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace SafeView.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PriceForMe { get; set; }

        [Required]
        public decimal PriceForSell { get; set; }

        public ICollection<SafeView.OrderProducts.OrderProduct> OrderProducts { get; set; }
    }
}
