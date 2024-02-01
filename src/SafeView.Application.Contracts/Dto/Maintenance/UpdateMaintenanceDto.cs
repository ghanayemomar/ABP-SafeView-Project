using System;

namespace SafeView.Dto.Maintenance
{
    public class UpdateMaintenanceDto : CreateMaintenanceDto
    {
        public Guid Id { get; set; }
    }
}
