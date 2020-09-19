using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DBEntities.Models
{
    [Table(nameof(Product))]
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? StockKeepingUnit { get; set; }
        public decimal? AvailableQuantity { get; set; }
        public string BarCode { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
