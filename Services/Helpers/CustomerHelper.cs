using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SampleAPI.Models;
using Dapper;

namespace SampleAPI.Services.Helpers
{
    public class CustomerHelper : ICustomerHelper
    {
        async Task<IEnumerable<T>> ICustomerHelper.GetAllCustomers<T>(IDbConnection connection, string commandText)
        {
            var query = await connection.QueryAsync<T>(commandText);
            return query;
        }

        async public Task AddCustomer(IDbConnection connection, Customer customer, string commandText)
        {
            await connection.ExecuteAsync(commandText,
               new { Id = customer.Id, OrganizationName = customer.OrganizationName, EmailAddress = customer.EmailAddress });
        }

        async public Task DeleteCustomer(IDbConnection connection, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText, new { Id = id });
        }



        async public ValueTask<T> GetCustomerById<T>(IDbConnection connection, int id, string commandText)
        {
            var query = await connection.QueryFirstOrDefaultAsync<T>(commandText, new { Id = id });
            return query;
        }

        async public Task UpdateCustomer(IDbConnection connection, Customer customer, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText,
            new { Id = id, OrganizationName = customer.OrganizationName, EmailAddress = customer.EmailAddress }); ;
        }
    }
}
