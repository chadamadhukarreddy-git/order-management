using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using OrderManagement.BusinessContracts;
using OrderManagement.Models.Common;

namespace OrderManagement.Services
{
    public class MailService : IMailService
    {
        #region Private Variables
        private readonly IConfiguration _configuration;
        private readonly SmtpConfigurationSettingsDTO _smtpConfigurationSetting;
        #endregion

        #region Constructor Logic
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
            var configKeyForSmtp = "SmtpConfiguration";
            var smtpConfigSection = _configuration.GetSection(configKeyForSmtp);
            if (smtpConfigSection.Exists())
                _smtpConfigurationSetting = smtpConfigSection.Get<SmtpConfigurationSettingsDTO>();

            VerifySmtpConfigSEction();
        }
        #endregion

        #region Public Methods
        
        public void SendOrderConfirmation(OrderComfirmationAlertDTO alertDTO)
        {
            var bodyHtml = @"<html><body>
                                Thank you for your order, your order has been confirmed!
                            </html></body>
                            ";
            var mailMessage = new MailMessage
            {
                 Subject = $"Order Confirmation - {alertDTO.OrderNumber}"
                ,IsBodyHtml = true
                ,From = new MailAddress(_smtpConfigurationSetting.FromEmail)
                ,Body = bodyHtml
            };
            mailMessage.To.Add(alertDTO.Email);
            SendEmail(mailMessage);
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
        private void SendEmail(string from, string to, string emailSubject, string emailBody, bool isBodyHtml)
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
        private void SendEmail(MailMessage message)
        {
            using var smtpClient = new SmtpClient(_smtpConfigurationSetting.Host, _smtpConfigurationSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpConfigurationSetting.UserName, _smtpConfigurationSetting.Password),
                EnableSsl = _smtpConfigurationSetting.IsEnableSSl
            };
            smtpClient.Send(message);
        }

        #endregion
    }
}
