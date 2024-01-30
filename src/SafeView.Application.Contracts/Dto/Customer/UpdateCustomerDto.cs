using System;

namespace SafeView.Dto.Customer
{
    public class UpdateCustomerDto : CreateCustomerDto
    {
        public Guid Id { get; set; }
    }
}
