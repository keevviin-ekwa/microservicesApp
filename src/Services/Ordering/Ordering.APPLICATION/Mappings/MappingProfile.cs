using AutoMapper;
using Ordering.APPLICATION.Features.Orders.Commands.CheckoutOrder;
using Ordering.APPLICATION.Features.Orders.Commands.UpdateOrder;
using Ordering.APPLICATION.Features.Orders.Queries.GetOrderList;
using Ordering.DOMAIN.Entities;

namespace Ordering.APPLICATION.Mappings
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order,CheckoutOrderCommad>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
