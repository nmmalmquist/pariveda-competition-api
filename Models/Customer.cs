using System;
namespace API.Models
{
    public class Customer
    {

        public Customer()
        {
            Deleted = false;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DateCreated { get; set; }

        public bool Deleted { get; set; }
    }
}