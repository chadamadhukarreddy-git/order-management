using OrderManagement.DBEntities.Models;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        #region Global Declarations
        #endregion

        #region Constructor Logic
        public AccountRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        #endregion
    }
}
