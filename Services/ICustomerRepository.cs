using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(Customer customer, int id);
    }
}
