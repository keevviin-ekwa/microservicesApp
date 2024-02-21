using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.APPLICATION.Contrats.Persistence;
using Ordering.APPLICATION.Exceptions;
using Ordering.DOMAIN.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.APPLICATION.Features.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderCommadHandler : IRequestHandler<DeleteOrderCommad>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommadHandler> _logger;

        public DeleteOrderCommadHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<DeleteOrderCommadHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOrderCommad request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
                //_logger.LogError("Order not exist on database");
            }

            await _orderRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
