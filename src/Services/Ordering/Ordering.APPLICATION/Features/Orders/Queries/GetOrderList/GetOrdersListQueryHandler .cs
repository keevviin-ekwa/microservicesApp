using AutoMapper;
using MediatR;
using Ordering.APPLICATION.Contrats.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.APPLICATION.Features.Orders.Queries.GetOrderList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this._mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList= await _orderRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}
