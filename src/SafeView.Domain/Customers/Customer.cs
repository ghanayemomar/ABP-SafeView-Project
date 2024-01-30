using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace SafeView.Customers
{
    public class Customer: FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(14)] 
        public string WhatsAppNumber { get; set; }  

        [Required]
        public string Location { get; set; }

        public ICollection<SafeView.Orders.Order> Orders { get; set; }

    }
}
