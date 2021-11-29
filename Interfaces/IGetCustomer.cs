using System.Collections.Generic;
using API.Models;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface IGetCustomer
    {
        Customer GetCustomer(string email);
        List<Customer> GetAllCustomers();
    }
}