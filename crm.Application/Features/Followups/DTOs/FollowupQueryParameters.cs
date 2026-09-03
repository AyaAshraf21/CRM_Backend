using crm.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.DTOs
{
    public class FollowupQueryParameters : BaseQueryParameters
    {
        public string? PhoneSearch { get; set; }
        public int? StatusId { get; set; }
        public int? deviceConditionId { get; set; }
        public int? platformId { get; set; }
        public int? paymentTypeId { get; set; }
        public int? operationTypeId { get; set; }
    }
}
