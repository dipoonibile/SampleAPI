using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPI.Models;
using System.Data;

namespace SampleAPI.Services.Helpers
{
    public interface ICustomerHelper
    {
        Task<IEnumerable<T>> GetAllCustomers<T>(IDbConnection connection, string commandText);
        ValueTask<T> GetCustomerById<T>(IDbConnection connection, int id, string commandText);
        Task AddCustomer(IDbConnection connection, Customer entity, string commandText);
        Task UpdateCustomer(IDbConnection connection, Customer entity, int id, string commandText);
        Task DeleteCustomer(IDbConnection connection, int id, string commandText);
    }
}
