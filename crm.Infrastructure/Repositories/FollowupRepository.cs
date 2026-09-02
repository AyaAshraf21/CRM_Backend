using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class FollowupRepository : IFollowupRepository
    {
        private readonly CRMContext context;

        public FollowupRepository(CRMContext context)
        {
            this.context = context;
        }
        public Task<List<Followup>> GetAllFollowupsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
