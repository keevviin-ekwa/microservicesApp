using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.APPLICATION.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommad : IRequest
    {
        public int Id { get; set; }
    }
}
