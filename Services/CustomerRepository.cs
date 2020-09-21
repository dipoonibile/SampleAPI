using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPI.Models;
using SampleAPI.Services.Queries;
using SampleAPI.Services.Helpers;
using Dapper;
using System.Data.Common;

namespace SampleAPI.Services
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly ICustomerCommandText _commandText;
        private readonly ICustomerHelper _customerHelper;

        public CustomerRepository(ICustomerCommandText commandText, DbConnection connection, ICustomerHelper customerHelper) : base(connection)
        {
            _commandText = commandText;
            _customerHelper = customerHelper;
        }
        public async Task AddCustomer(Customer customer)
        {

            await WithConnection(async conn =>
            {
                await _customerHelper.AddCustomer(conn, customer, _commandText.AddCustomer);
            });
        }



        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {

            return await WithConnection(async conn =>
            {
                var query = await _customerHelper.GetAllCustomers<Customer>(conn, _commandText.GetCustomers);
                return query;
            });

        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await _customerHelper.GetCustomerById<Customer>(conn, id, _commandText.GetCustomerById);
                return query;
            });
        }
        public async Task UpdateCustomer(Customer customer, int id)
        {
            await WithConnection(async conn =>
            {
                await _customerHelper.UpdateCustomer(conn, customer, id, _commandText.UpdateCustomer);
            });

        }

        public async Task DeleteCustomer(int id)
        {
            await WithConnection(async conn =>
            {
                await _customerHelper.DeleteCustomer(conn, id, _commandText.DeleteCustomer);
            });
        }

    }
}
