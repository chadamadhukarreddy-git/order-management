using OrderManagement.BusinessContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Services
{
    public class AppCacheService : IAppCacheService
    {
        public readonly IMailService _mailService;
        public AppCacheService(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IMailService MailService { get => _mailService; }
    }
}
