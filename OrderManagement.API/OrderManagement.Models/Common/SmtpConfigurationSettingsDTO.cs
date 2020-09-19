using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Models.Common
{
    public class SmtpConfigurationSettingsDTO
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public bool IsEnableSSl { get; set; }
    }
}
