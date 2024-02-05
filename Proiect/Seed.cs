using Proiect.Data;
using Proiect.Models;

namespace Proiect
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Apartment.Any())
            {
                var apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Name = "Luxury Suite",
                        ApartmentCategories = new List<ApartmentCategory>
                        {
                            new ApartmentCategory { Category = new Category { Name = "Luxury" } }
                        },
                        Reviews = new List<Review>
                        {
                            new Review { Title = "Amazing Suite", Text = "This suite is fantastic!", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "John", LastName = "Doe" } },
                            new Review { Title = "Highly Recommended", Text = "I loved my stay in this luxury suite.", Rating = 4,
                                Reviewer = new Reviewer { FirstName = "Jane", LastName = "Smith" } }
                        }
                    },
                    new Apartment
                    {
                        Name = "Cozy Studio",
                        ApartmentCategories = new List<ApartmentCategory>
                        {
                            new ApartmentCategory { Category = new Category { Name = "Cozy" } }
                        },
                        Reviews = new List<Review>
                        {
                            new Review { Title = "Small but Comfortable", Text = "Perfect for a solo traveler.", Rating = 4,
                                Reviewer = new Reviewer { FirstName = "Alice", LastName = "Johnson" } },
                            new Review { Title = "Great Experience", Text = "I enjoyed my stay in this cozy studio.", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Bob", LastName = "Miller" } }
                        }
                    },
                    new Apartment
                    {
                        Name = "Family Apartment",
                        ApartmentCategories = new List<ApartmentCategory>
                        {
                            new ApartmentCategory { Category = new Category { Name = "Family-Friendly" } }
                        },
                        Reviews = new List<Review>
                        {
                            new Review { Title = "Perfect for Families", Text = "Spacious and child-friendly.", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Emily", LastName = "Clark" } },
                            new Review { Title = "Excellent Stay", Text = "We had a great time in this family apartment.", Rating = 4,
                                Reviewer = new Reviewer { FirstName = "David", LastName = "Brown" } }
                        }
                    }
                };

                dataContext.Apartment.AddRange(apartments);
                dataContext.SaveChanges();
            }
        }
    }
}
