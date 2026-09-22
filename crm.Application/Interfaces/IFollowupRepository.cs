using crm.Application.Features.Followups.DTOs;
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
        public Task<(List<Followup> , int totalCount)> GetAllFollowupsAsync(FollowupQueryParameters followupQueryParameters);
        public void CreateFollowup(Followup followup);
        public void UpdateFollowup(Followup followup);
        public Task<Followup> GetFollowupByIdAsync(int id);
        public Task<int> GetFollowupsNumAsync();
    }
}
