using crm.Application.Features.Followups.DTOs;
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
    public class FollowupRepository : IFollowupRepository
    {
        private readonly CRMContext context;

        public FollowupRepository(CRMContext context)
        {
            this.context = context;
        }
        public async Task<(List<Followup>, int totalCount)> GetAllFollowupsAsync(FollowupQueryParameters followupQueryParameters)
        {
            var query = context.Followups
                            .Include(f =>f.StatusHistory)
                            .Include(f => f.Customer)
                            .ThenInclude(c => c.Area)
                            .ThenInclude(a => a.Governorate)
                            .Include(f => f.Customer)
                            .ThenInclude(c => c.Tag)
                            .Where(f => !f.IsDeleted)
                                .Select(f => new
                                {
                                    Followup = f,
                                    LastStatus = f.StatusHistory.OrderByDescending(s => s.ChangedAt)
                                                                .Select(s => s.Status)
                                                                .FirstOrDefault()
                                });

            // search by name or phone
            if (!string.IsNullOrWhiteSpace(followupQueryParameters.Search))
            {
                query = query.Where(f => f.Followup.Customer.Name.Contains(followupQueryParameters.Search)
                                        || f.Followup.Customer.Phone.Contains(followupQueryParameters.Search));
            }

            //search by device type
            if (!string.IsNullOrWhiteSpace(followupQueryParameters.PhoneSearch))
            {
                query = query.Where(f => f.Followup.DeviceType.Contains(followupQueryParameters.PhoneSearch));
            }

            //governorate
            if (followupQueryParameters.GovernorateId.HasValue)
            {
                query = query.Where(f => f.Followup.Customer.Area.GovernorateId == followupQueryParameters.GovernorateId.Value);
            }

            //area
            if(followupQueryParameters.AreaId.HasValue && followupQueryParameters.GovernorateId.HasValue)
            {
                query = query.Where(f => f.Followup.Customer.AreaId == followupQueryParameters.AreaId.Value);
            }

            //tag
            if (followupQueryParameters.TagId.HasValue)
            {
                query = query.Where(f => f.Followup.Customer.TagId == followupQueryParameters.TagId.Value);
            }

            //status
            if (followupQueryParameters.StatusId.HasValue)
            {
                query = query.Where(f => (int)f.LastStatus == followupQueryParameters.StatusId);
            }

            //platform
            if (followupQueryParameters.platformId.HasValue)
            {
                query = query.Where(f => (int)f.Followup.Platform == followupQueryParameters.platformId.Value);
            }

            //payment type
            if (followupQueryParameters.paymentTypeId.HasValue)
            {
                query = query.Where(f => (int)f.Followup.PaymentType == followupQueryParameters.paymentTypeId.Value);
            }

            //operation type
            if (followupQueryParameters.operationTypeId.HasValue)
            {
                query = query.Where(f => (int)f.Followup.OperationType == followupQueryParameters.operationTypeId.Value);
            }

            //device condition
            if (followupQueryParameters.deviceConditionId.HasValue)
            {
                query = query.Where(f => (int)f.Followup.DeviceCondition == followupQueryParameters.deviceConditionId.Value);
            }

            var totalCount = await query.CountAsync();


            //pagination
            query = query.OrderBy(f => f.Followup.Id)
                         .Skip((followupQueryParameters.Page - 1) * followupQueryParameters.PerPage)
                         .Take(followupQueryParameters.PerPage);

            var followups = await query.Select(x => x.Followup).ToListAsync();
            return (followups , totalCount);
        }

        public void CreateFollowup(Followup followup)
        {
            context.Followups.Add(followup);
        }
        public void UpdateFollowup(Followup followup)
        {
            context.Followups.Update(followup);
        }

        public async Task<Followup> GetFollowupByIdAsync(int id)
        {
            return await context.Followups
                .Include(f => f.StatusHistory)
                .Include(f => f.Customer)
                .ThenInclude(c => c.Area)
                .ThenInclude(a => a.Governorate)
                .Include(f => f.Customer)
                .ThenInclude(c => c.Tag)
                .Where(f => !f.IsDeleted)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
