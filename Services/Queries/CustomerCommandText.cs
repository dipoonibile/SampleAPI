using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Services.Queries
{
    public class CustomerCommandText:ICustomerCommandText
    {
        string GetCustomers { get; }
        string GetCustomerById { get; }
        string AddCustomer { get; }
        string DeleteCustomer { get; }
        string UpdateCustomer { get; }
    }
}
