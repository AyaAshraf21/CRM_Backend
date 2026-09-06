using crm.Application.Features.Customers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.DTOs
{
    public class FollowupResponseDTO
    {
        public int Id { get; set; }
        public CustomerResponseDTO Customer { get; set; }
        public string DeviceType { get; set; }
        public string Platform { get; set; }
        public string Status { get; set; }
        public string DeviceCondition { get; set; }
        public string OperationType { get; set; }
        public string PaymentType { get; set; }
        public string? Notes { get; set; }
    }
}
