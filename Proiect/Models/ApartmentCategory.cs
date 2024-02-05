namespace Proiect.Models
{
    public class ApartmentCategory
    {
        public int ApartmentId { get; set; }
        public int CategoryId { get; set; }
        public Apartment Apartment { get; set; }
        public Category Category { get; set; }
    }
}
