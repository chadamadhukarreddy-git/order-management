using OrderManagement.Models.Result;
using OrderManagement.DBEntities.Models;
using System.Collections.Generic;

namespace OrderManagement.Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        WriteResult UpdateOrderStatus(Order order);
        public Order Get(long id);
    }
}
