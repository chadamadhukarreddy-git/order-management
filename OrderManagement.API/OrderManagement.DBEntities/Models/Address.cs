using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DBEntities.Models
{
    [Table(nameof(Address))]
    public partial class Address
    {
        public Address()
        {
            OrderBillToAddress = new HashSet<Order>();
            OrderShipToAddress = new HashSet<Order>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AddressId { get; set; }
        public long? UserId { get; set; }
        public int? AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public int? PinCode { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> OrderBillToAddress { get; set; }
        public virtual ICollection<Order> OrderShipToAddress { get; set; }
    }
}
