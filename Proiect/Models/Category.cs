namespace Proiect.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ApartmentCategory> ApartmentCategories { get; set; }
    }
}
