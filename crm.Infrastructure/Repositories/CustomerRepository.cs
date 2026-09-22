using crm.Application.Features.Customers.DTOs;
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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CRMContext context;

        public CustomerRepository(CRMContext context)
        {
            this.context = context;
        }

        public async Task<(List<Customer>, int totalCount)> GetAllCustomersAsync(CustomerQueryParameters customerQueryParameters)
        {
            var query = context.Customers.Where(c => !c.IsDeleted);

            //search
            if (!string.IsNullOrWhiteSpace(customerQueryParameters.Search))
            {
                query = query.Where(c => 
                    c.Name.Contains(customerQueryParameters.Search)||
                    c.Phone.Contains(customerQueryParameters.Search)
                );
            }

            // governorate
            if (customerQueryParameters.GovernorateId.HasValue)
            {
                query = query.Where(c => c.Area.GovernorateId == customerQueryParameters.GovernorateId.Value);
            }

            // area
            if (customerQueryParameters.AreaId.HasValue && customerQueryParameters.GovernorateId.HasValue)
            {
                query = query.Where(c => c.AreaId == customerQueryParameters.AreaId.Value);
            }

            //tag
            if(customerQueryParameters.TagId.HasValue)
            {
                query = query.Where(c => c.TagId == customerQueryParameters.TagId.Value);
            }

            var totalCount = await query.CountAsync();


            query = query.Include(c => c.Area)
                .ThenInclude(a => a.Governorate)
                .Include(c => c.Tag);

            //pagination
            query = query
                .OrderBy(c => c.Id)
                .Skip((customerQueryParameters.Page - 1) * customerQueryParameters.PerPage)
                .Take(customerQueryParameters.PerPage);

            var customers = await query.ToListAsync();

            return (customers, totalCount);
        }
        
        public void CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public async Task<bool> IsPhoneNumberExistsAsync(string phoneNumber)
        {
            return await context.Customers.AnyAsync(x => x.Phone == phoneNumber);
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return context.Customers
                .Include(c => c.Area)
                .ThenInclude(c => c.Governorate)
                .Include(c => c.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetCustomerByPhoneAsync(string phone)
        {
            return await context.Customers
                .Include(c => c.Area)
                .ThenInclude(c => c.Governorate)
                .Include(c => c.Tag)
                .FirstOrDefaultAsync(c => c.Phone == phone);
        }

        public async Task<Customer> GetCustomerByIdWithDeletedAsync(int id)
        {
            return await context.Customers
                .Include(c => c.Area)
                .ThenInclude(c => c.Governorate)
                .Include(c => c.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<int> GetCustomersNumAsync()
        {
            return context.Customers.CountAsync();
        }
    }
}
