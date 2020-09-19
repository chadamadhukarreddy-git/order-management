using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Models
{
    public class OrderDTO : OrderBaseDTO
    {
        public OrderDTO()
        {
            OrderDetail = new List<OrderDetailDTO>();
        }
        public List<OrderDetailDTO> OrderDetail { get; set; }
    }
}
