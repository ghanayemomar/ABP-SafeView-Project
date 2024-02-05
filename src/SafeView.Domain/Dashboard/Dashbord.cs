using System.ComponentModel.DataAnnotations.Schema;

namespace SafeView.Dashboard
{
    [NotMapped]
    public class OrderDashboard
    {
        public int OrdersCount { get; set; }    
        public int PedningOrdersCount { get; set; }
        public int AcceptedOrdersCount { get; set; }
        public int RejectedOrdersCount { get; set; }
    }
    public class ProductDashboard
    {
        public int ProductCount { get; set; }
    }
    public class CustomerDashboard
    {
        public int CustomerCount { get; set; }  
    }
    public class MaintenanceDashboard
    {
        public int MaintenanceCount { get; set; }
    }
}
