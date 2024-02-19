using MediatR;
using System.Collections.Generic;

namespace Ordering.APPLICATION.Features.Orders.Queries.GetOrderList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }
    }
}
