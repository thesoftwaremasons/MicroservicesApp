using Ordering.Core.Entities.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities
{
   public interface IOrderRepository:IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserName(string userName);

    }
}
