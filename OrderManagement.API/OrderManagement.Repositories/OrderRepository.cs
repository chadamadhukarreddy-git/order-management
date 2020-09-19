using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagement.DBEntities.Models;
using OrderManagement.Models.Result;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        #region Global Declarations
        #endregion

        #region Constructor Logic
        public OrderRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        public new IQueryable<Order> GetAll()
        {
            return RepositoryContext.Order.Include("OrderDetail");
        }
        public Order Get(long id)
        {
            return RepositoryContext.Order.Include("OrderDetail").FirstOrDefault(a => a.OrderId == id);
        }
        public WriteResult UpdateOrderStatus(Order order)
        {
            var result = new WriteResult();
            try
            {
                var orderItem = Get<long>(order.OrderId);                
                orderItem.OrderStatusId = order.OrderStatusId;
                orderItem.UpdatedBy = order.UpdatedBy;
                orderItem.UpdatedDate = DateTime.Now;
            }
            catch
            {
                throw;
            }

            return result;
        }
        #endregion
    }
}
