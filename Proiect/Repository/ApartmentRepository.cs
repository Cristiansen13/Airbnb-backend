using Proiect.Data;
using Proiect.Dto;
using Proiect.Interface;
using Proiect.Models;

namespace Proiect.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly DataContext _context;

        public ApartmentRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateApartment(int ownerId, int categoryId, Apartment pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new ApartmentOwner()
            {
                Owner = pokemonOwnerEntity,
                Apartment = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new ApartmentCategory()
            {
                Category = category,
                Apartment = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool DeleteApartment(Apartment pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public Apartment GetApartment(int id)
        {
            return _context.Apartment.Where(p => p.Id == id).FirstOrDefault();
        }

        public Apartment GetApartment(string name)
        {
            return _context.Apartment.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetApartmentRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Apartment.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Apartment> GetApartments()
        {
            return _context.Apartment.OrderBy(p => p.Id).ToList();
        }

        public Apartment GetApartmentTrimToUpper(ApartmentDto pokemonCreate)
        {
            return GetApartments().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool ApartmentExists(int pokeId)
        {
            return _context.Apartment.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateApartment(int ownerId, int categoryId, Apartment pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
