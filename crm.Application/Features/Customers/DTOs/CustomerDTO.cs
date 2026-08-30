using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GovernorateId { get; set; }
        public int AreaId { get; set; }
        public int TagId { get; set; } = 1;
    }
}
