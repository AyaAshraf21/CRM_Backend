using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.DTOs
{
    public class DeviceConditionAnalyticsDTO
    {
        public DeviceCondition DeviceConditionId { get; set; }
        public string DeviceCondition { get; set; }
        public int FollowupCount { get; set; }
    }
}
