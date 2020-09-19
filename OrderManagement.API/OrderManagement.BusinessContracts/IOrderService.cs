using OrderManagement.DBEntities.Models;
using OrderManagement.Models;
using OrderManagement.Models.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.BusinessContracts
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order Get(long id);

        IEnumerable<OrderDetail> GetDetails(long orderId);
        WriteResult Create(OrderDTO order);
        WriteResult Update(OrderDTO order);
        WriteResult Delete(long id);
        WriteResult UpdateOrderStatus(OrderDTO order);
        
    }
}
