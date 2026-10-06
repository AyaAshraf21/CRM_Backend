using crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.DTOs
{
    public class CustomerTagAnalyticsDTO
    {
        public int TagId { get; set; }
        public string Tag { get; set; }
        public int CustomerCount { get; set; }
    }
}
