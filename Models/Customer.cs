using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string EmailAddress { get; set; }
    }
}
