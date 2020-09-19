using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Repositories.Contracts
{
    public interface IOrderUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IAccountRepository AccountRepository { get; }
        int Save();
    }
}
