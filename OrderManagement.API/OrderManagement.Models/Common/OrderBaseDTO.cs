using OrderManagement.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagement.Models
{
    public class OrderBaseDTO
    {
        public long OrderId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public long? AccountId { get; set; }
        public long? BillToAdressId { get; set; }
        public long? ShipToAdressId { get; set; }
        public int? OrderStatusId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
