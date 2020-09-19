using OrderManagement.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Repositories.Contracts
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        IEnumerable<OrderDetail> GetOrderDetails(long orderId);
    }
}
