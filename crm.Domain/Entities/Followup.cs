using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Entities
{
    public class Followup : BaseEntity
    {
        public int CustomerId { get; set; }
        public PaymentType PaymentType { get; set; }
        public DeviceCondition DeviceCondition { get; set; }
        public OperationType OperationType { get; set; }
        public Platform Platform { get; set; }
        public string DeviceType { get; set; } = null!;
        public string? Notes { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<StatusFollowup> StatusHistory { get; set; } = [];
    }
}
