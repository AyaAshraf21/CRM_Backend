using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Domain.Enums
{
    public enum Status
    {
        NewFollowup = 1,
        OnTheWay = 2,
        NoAnswer = 3,
        Postponed = 4,
        Cancelled = 5,
        Purchased = 6,
        InstallmentAccepted = 7,
        InstallmentRejected = 8,
    }
}
