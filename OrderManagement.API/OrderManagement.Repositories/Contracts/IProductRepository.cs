using OrderManagement.DBEntities.Models;
using OrderManagement.Models.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void ReduceQuntity(long productId, decimal quntity);
    }
}
