using crm.Application.Features.Customers.DTOs;
using crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<(List<Customer>, int totalCount)> GetAllCustomersAsync(CustomerQueryParameters customerQueryParameters);
        public void CreateCustomer(Customer customer);
        public Task<bool> IsPhoneNumberExistsAsync(string phoneNumber);
        public void UpdateCustomer(Customer customer);
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> GetCustomerByPhoneAsync(string phone);
    }
}
