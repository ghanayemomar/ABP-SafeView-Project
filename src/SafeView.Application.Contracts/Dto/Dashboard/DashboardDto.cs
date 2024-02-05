namespace SafeView.Dto.Dashboard
{
    public class OrderDashboardDto
    {
        public int OrdersCount { get; set; }
        public int PedningOrdersCount { get; set; }
        public int AcceptedOrdersCount { get; set; }
        public int RejectedOrdersCount { get; set; }
    }
    public class ProductDashboardDto
    {
        public int ProductCount { get; set; }
    }
    public class CustomerDashboardDto
    {
        public int CustomerCount { get; set; }
    }
    public class MaintenanceDashboardDto
    {
        public int MaintenanceCount { get; set; }
    }
}
