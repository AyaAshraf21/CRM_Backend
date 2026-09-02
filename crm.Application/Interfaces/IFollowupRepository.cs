using crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Interfaces
{
    public interface IFollowupRepository
    {
        public Task<List<Followup>> GetAllFollowupsAsync();
    }
}
