using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Common.Pagination
{
    public class BaseQueryParameters
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
        public int? GovernorateId { get; set; }
        public int? AreaId { get; set; }
        public int? TagId { get; set; }
    }
}
