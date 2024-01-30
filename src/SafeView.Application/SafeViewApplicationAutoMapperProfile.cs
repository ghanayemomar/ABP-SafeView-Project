using AutoMapper;
using SafeView.Dto.Customer;
using SafeView.Dto.Maintenance;
using SafeView.Dto.Order;
using SafeView.Dto.OrderProduct;
using SafeView.Dto.Product;

namespace SafeView;

public class SafeViewApplicationAutoMapperProfile : Profile
{
    public SafeViewApplicationAutoMapperProfile()
    {
        //Customer Auto Mapper:
        CreateMap<CreateCustomerDto, SafeView.Customers.Customer>();
        CreateMap<UpdateCustomerDto, SafeView.Customers.Customer>();
        CreateMap<SafeView.Customers.Customer, CustomerDto>().ReverseMap();


        // Maintenance mappings
        CreateMap<CreateMaintenanceDto, SafeView.Maintenance.Maintenance>();
        CreateMap<UpdateMaintenanceDto, SafeView.Maintenance.Maintenance>();
        CreateMap<SafeView.Maintenance.Maintenance, MaintenanceDto>().ReverseMap(); 


        //Product Auto Mapper:
        CreateMap<CreateProductDto, SafeView.Products.Product>();
        CreateMap<UpdateProductDto, SafeView.Products.Product>();
        CreateMap<SafeView.Products.Product, ProductDto>().ReverseMap();


        //Order Auto Mapper:
        CreateMap<CreateOrderDto, SafeView.Orders.Order>();
        CreateMap<UpdateOrderDto, SafeView.Orders.Order>();
        CreateMap<SafeView.Orders.Order, OrderDto>().ReverseMap();


        //OrderProduct Auto Mapper:
        CreateMap<SafeView.OrderProducts.OrderProduct, OrderProductDto>();


    }
}
