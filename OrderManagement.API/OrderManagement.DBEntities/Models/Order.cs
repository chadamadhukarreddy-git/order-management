using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DBEntities.Models
{
    [Table(nameof(Order))]
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public long? AccountId { get; set; }
        public long? BillToAddressId { get; set; }
        public long? ShipToAddressId { get; set; }
        public int? OrderStatusId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Address BillToAddress { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Address ShipToAddress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
