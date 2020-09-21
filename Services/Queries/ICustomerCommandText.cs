using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Services.Queries
{
    public interface ICustomerCommandText
    {
        public string GetCustomers => "Select * from Customer";
        public string GetCustomerById => "Select * from Customer where Id= @Id";
        public string AddCustomer => "Insert into  [dbo].[Customer] (OrganizationName, EmailAddress, CreatedDate) values (@OrganizationName, @EmailAddress, @CreatedDate)";
        public string UpdateCustomer => "";
        public string DeleteCustomer => "Delete from [dbo].[Customer] where Id= @Id";
    }
}
