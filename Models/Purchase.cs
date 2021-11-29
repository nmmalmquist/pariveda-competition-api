using System;

namespace API.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
    }
}