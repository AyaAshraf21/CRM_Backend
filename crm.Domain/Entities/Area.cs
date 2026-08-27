using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; } = null!;
        public ICollection<Customer> Customers { get; set; } = [];
    }           
}
