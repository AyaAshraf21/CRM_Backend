using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.DTOs
{
    public class PlatformsAnalyticsDTO
    {
        public Platform Platform { get; set; }
        public int FollowupCount { get; set; }
        public int PurchasedCount { get; set; }
        public double ConversionRate { get; set; }
    }
}
