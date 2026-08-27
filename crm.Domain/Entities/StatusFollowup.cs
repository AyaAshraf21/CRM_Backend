using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Entities
{
    public class StatusFollowup
    {
        public int Id { get; set; }
        public int FollowupId { get; set; }
        public Status Status { get; set; }
        public DateTime ChangedAt { get; set; }
        public string? Notes { get; set; }
        public Followup Followup { get; set; } = null!;
    }
}
