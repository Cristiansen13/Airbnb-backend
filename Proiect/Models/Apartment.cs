namespace Proiect.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartRentingDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ApartmentOwner> ApartmentPastOwners { get; set; }
        public ICollection<ApartmentCategory> ApartmentCategories { get; set; }
    }
}
