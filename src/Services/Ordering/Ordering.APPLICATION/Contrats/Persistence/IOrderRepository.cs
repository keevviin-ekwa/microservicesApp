using Ordering.DOMAIN.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.APPLICATION.Contrats.Persistence
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
