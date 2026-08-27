using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int AreaId { get; set; }
        public int? TagId { get; set; }
        public bool IsDeleted { get; set; }
        public Area Area { get; set; } = null!;
        public Tag? Tag { get; set; }
        public ICollection<Followup> Followups { get; set; } = [];
    }
}
