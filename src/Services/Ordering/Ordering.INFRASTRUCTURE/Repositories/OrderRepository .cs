using Microsoft.EntityFrameworkCore;
using Ordering.APPLICATION.Contrats.Persistence;
using Ordering.DOMAIN.Entities;
using Ordering.INFRASTRUCTURE.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.INFRASTRUCTURE.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
       
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders //vient  de Repository base
                                   .Where(o => o.UserName == userName)
                                   .ToListAsync();
            return orderList;
        }
    }
}
