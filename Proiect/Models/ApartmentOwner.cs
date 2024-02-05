namespace Proiect.Models
{
    public class ApartmentOwner
    {
        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }
        public Apartment Apartment { get; set; }
        public Owner Owner { get; set; }
    }
}
