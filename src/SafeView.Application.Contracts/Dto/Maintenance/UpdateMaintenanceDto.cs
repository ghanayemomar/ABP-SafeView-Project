using System;
using System.Collections.Generic;
using System.Text;

namespace SafeView.Dto.Maintenance
{
    public class UpdateMaintenanceDto : CreateMaintenanceDto
    {
        public Guid Id { get; set; }
    }
}
