using System;
namespace API.Models
{
    public class Admin
    {
        public Admin()
        {
            Deleted = false;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateInitialized { get; set; }
        public DateTime DateTerminated { get; set; }
        public bool Deleted { get; set; }

    }
}