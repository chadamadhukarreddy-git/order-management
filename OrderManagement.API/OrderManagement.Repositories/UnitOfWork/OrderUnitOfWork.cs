using OrderManagement.DBEntities.Models;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Repositories
{
    public class OrderUnitOfWork : IOrderUnitOfWork
    {
        #region Global Declarations
        private readonly OrderManagementDbContext _dbContext;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IAccountRepository _accountRepository;
        #endregion

        #region Constructor Logic
        public OrderUnitOfWork(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Properties
        public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new OrderRepository(_dbContext));
        public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(_dbContext));
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository ?? (_orderDetailRepository = new OrderDetailRepository(_dbContext));
        public IAccountRepository AccountRepository => _accountRepository ?? (_accountRepository = new AccountRepository(_dbContext));
        #endregion

        #region Public Methods
        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        public void ResetRepositories()
        {
            _orderRepository = null;
            _productRepository = null;
            _orderDetailRepository = null;
            _accountRepository = null;
        }
        #endregion
    }
}
