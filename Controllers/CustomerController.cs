using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [EnableCors("dogDBPolicy")]
        [HttpGet]
        public List<Customer> Get()
        {
            IGetCustomer readObject = new GetCustomer();
            return readObject.GetAllCustomers();
        }

        // GET: api/Customer/5
        [EnableCors("dogDBPolicy")]
        [HttpGet("{email}", Name = "Get")]
        public Customer Get(string email)
        {
            IGetCustomer readObject = new GetCustomer();
            return readObject.GetCustomer(email);
        }

        // POST: api/Customer
        [EnableCors("dogDBPolicy")]
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            ISaveCustomer saveObj = new SaveCustomer();
            saveObj.AddCustomer(customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        [EnableCors("dogDBPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteCustomer deleteObj = new DeleteCustomer();
            deleteObj.DeleteCustomer(id);
        }
    }
}
