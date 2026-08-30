using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CRMContext context;

        public TagRepository(CRMContext context)
        {
            this.context = context;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await context.Tags.ToListAsync();
        }

        public async Task<bool> IsTagExistsById(int tagId)
        {
            return await context.Tags.AnyAsync(t => t.Id == tagId);
        }
    }
}
