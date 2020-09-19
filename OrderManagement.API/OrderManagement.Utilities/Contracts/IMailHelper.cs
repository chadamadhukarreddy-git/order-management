using System.Net.Mail;

namespace OrderManagement.Utilities.Contracts
{
    public interface IMailHelper
    {
        public void SendEmail(MailMessage message);
        public void SendEmail(string from, string to, string emailSubject, string emailBody, bool isBodyHtml);
    }
}
