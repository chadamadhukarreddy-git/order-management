using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.DBEntities.Models
{
    public interface IEntity<TId> where TId : class
    {
        TId Id { get; set; }
    }
}
