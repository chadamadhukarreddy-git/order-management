using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.BusinessContracts
{
    public interface IAppCacheService
    {
        IMailService MailService { get; }
    }
}
