using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace OrderManagement.Utilities
{
    public class MailHelper
    {
        #region Private Variables
        private readonly IConfiguration _configuration;
        private readonly SmtpConfigurationSettings _smtpConfigurationSetting;
        #endregion

        #region Constructor Logic
        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            var configKeyForSmtp = "SmtpConfiguration";
            var smtpConfigSection = _configuration.GetSection(configKeyForSmtp);
            if (smtpConfigSection.Exists())
                _smtpConfigurationSetting = smtpConfigSection.Get<SmtpConfigurationSettings>();

            VerifySmtpConfigSEction();
        }
        #endregion

        #region Public Methods
        public void SendEmail(string from, string to, string emailSubject, string emailBody, bool isBodyHtml)
        {
            using var smtpClient = new SmtpClient(_smtpConfigurationSetting.Host, _smtpConfigurationSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpConfigurationSetting.UserName, _smtpConfigurationSetting.Password),
                EnableSsl = _smtpConfigurationSetting.IsEnableSSl
            };

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject = emailSubject;
            message.From = new MailAddress(from);
            message.Body = $"{ emailBody}{GetDisclaimer()}";
            message.IsBodyHtml = isBodyHtml;
            smtpClient.Send(message);
        }
        public void SendEmail(MailMessage message)
        {
            using var smtpClient = new SmtpClient(_smtpConfigurationSetting.Host, _smtpConfigurationSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpConfigurationSetting.UserName, _smtpConfigurationSetting.Password),
                EnableSsl = _smtpConfigurationSetting.IsEnableSSl
            };
            smtpClient.Send(message);
        }
        #endregion

        #region Private Methods
        private void VerifySmtpConfigSEction()
        {
            if (_smtpConfigurationSetting == null)
                throw new ArgumentNullException("Smtp Configuration Settings required");
            if (string.IsNullOrWhiteSpace(_smtpConfigurationSetting.Host))
                throw new ArgumentNullException("Smtp Host is not configured");
            if (string.IsNullOrWhiteSpace(_smtpConfigurationSetting.UserName))
                throw new ArgumentNullException("Smtp UserName is not configured");
            if (string.IsNullOrWhiteSpace(_smtpConfigurationSetting.Password))
                throw new ArgumentNullException("Smtp Password is not configured");
        }
        private string GetDisclaimer()
        {
            return "<br/><br/><br/>Regards,<br/>This is an auto generated email from [Company]";
        }
        #endregion

    }

    public class SmtpConfigurationSettings
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
