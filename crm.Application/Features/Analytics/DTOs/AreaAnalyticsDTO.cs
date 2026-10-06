using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.DTOs
{
    public class AreaAnalyticsDTO
    {

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int GovernorateId { get; set; }
        public string GovernorateName { get; set; }
        public int SalesCount { get; set; }
    }
}
