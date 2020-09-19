using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DBEntities.Models
{
    [Table(nameof(User))]
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
            Address = new HashSet<Address>();
            UserRole = new HashSet<UserRole>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public bool IsActive { get; set; }
        public int? LoginAttempts { get; set; }
        public bool IsAccountLocked { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
