using OrderManagement.Models.Common;
using System.Net.Mail;

namespace OrderManagement.BusinessContracts
{
    public interface IMailService
    {
        void SendOrderConfirmation(OrderComfirmationAlertDTO alertDTO);
    }
}
