using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Entities
{
    public class Governorate : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Area> Areas { get; set; } = [];
    }
}
