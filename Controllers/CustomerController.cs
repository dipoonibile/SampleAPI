using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Services;
using SampleAPI.Models;
namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Update(Customer customer, int id)
        {
            await _customerRepository.UpdateCustomer(customer, id);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerRepository.DeleteCustomer(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var product = await _customerRepository.GetCustomerById(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAll()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

    }
}