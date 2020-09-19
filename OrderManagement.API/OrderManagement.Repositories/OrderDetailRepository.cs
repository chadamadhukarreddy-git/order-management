using OrderManagement.DBEntities.Models;
using OrderManagement.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        #region Global Declarations
        private readonly OrderManagementDbContext _dbContext;
        #endregion

        #region Constructor Logic
        public OrderDetailRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods
        public IEnumerable<OrderDetail> GetOrderDetails(long orderId)
        {
            return from order in _dbContext.Order
                    join orderDetail in _dbContext.OrderDetail on order.OrderId equals orderDetail.OrderId
                    select orderDetail;
        }
        #endregion
    }
}
