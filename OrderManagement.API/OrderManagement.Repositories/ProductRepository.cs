using OrderManagement.DBEntities.Models;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        #region Global Declarations
        private readonly OrderManagementDbContext _dbContext;
        #endregion

        #region Constructor Logic
        public ProductRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods
        public void ReduceQuntity(long productId, decimal quantity)
        {
            var product = _dbContext.Product.FirstOrDefault(a => a.ProductId == productId);
            if(product != null)
            {
                product.AvailableQuantity -= quantity;
            }
        }
        #endregion
    }
}
