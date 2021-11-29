
namespace API.Models
{
    public class Dog
    {

        public Dog()
        {
            Deleted = false;
        }
        public int Id { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SaleType { get; set; }
        public string MainImageName { get; set; }
        public string Image1Name { get; set; }
        public string Image2Name { get; set; }
        public string Image3Name { get; set; }
        public bool Deleted { get; set; }

    }
}