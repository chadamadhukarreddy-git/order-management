using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Models.Common
{
    public class OrderComfirmationAlertDTO
    {
        public string Email { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderDetailDTO> OrderProducts { get; set; }

    }
}
