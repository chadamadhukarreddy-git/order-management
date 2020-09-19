using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Models
{
    public class OrderDetailDTO
    {
        public long OrderDetailId { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
