using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.DTOs
{
    public class PaymentTypeAnalyticsDTO
    {
        public PaymentType PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public int FollowupCount { get; set; }
    }
}
