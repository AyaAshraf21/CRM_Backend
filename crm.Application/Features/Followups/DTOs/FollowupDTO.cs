using crm.Application.Features.Customers.DTOs;
using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.DTOs
{
    public class FollowupDTO
    {
        public string DeviceType { get; set; }
        public Platform Platform { get; set; }
        public Status Status { get; set; } = Status.NewFollowup;
        public DeviceCondition DeviceCondition { get; set; }
        public OperationType OperationType { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? Notes { get; set; }
    }
}
