using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CustomersController : ControllerBase
    {
        private readonly DataService _dataService;

        public CustomersController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = _dataService.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Customers.Remove(customer);
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return _dataService.Customers;
        }

        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            var customer = _dataService.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException();
            }

            return customer;
        }

        [HttpPost]
        public void Create(Customer customer)
        {
            _dataService.Customers.Add(customer);
        }

        [HttpPut]
        public void Update(Customer customer)
        {
            var customerToUpdate = _dataService.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (customerToUpdate == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Customers[customer.Id] = customer;
        }
    }
}
