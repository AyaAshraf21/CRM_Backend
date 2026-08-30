using crm.Application.Interfaces;
using crm.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMContext context;
        public UnitOfWork(CRMContext context)
        {
            this.context = context;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
