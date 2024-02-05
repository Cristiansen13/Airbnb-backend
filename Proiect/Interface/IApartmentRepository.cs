using Proiect.Dto;
using Proiect.Models;

namespace Proiect.Interface
{
    public interface IApartmentRepository
    {
        ICollection<Apartment> GetApartments();
        Apartment GetApartment(int id);
        Apartment GetApartment(string name);
        Apartment GetApartmentTrimToUpper(ApartmentDto apartmentCreate);
        decimal GetApartmentRating(int pokeId);
        bool ApartmentExists(int pokeId);
        bool CreateApartment(int ownerId, int categoryId, Apartment apartment);
        bool UpdateApartment(int ownerId, int categoryId, Apartment apartment);
        bool DeleteApartment(Apartment apartment);
        bool Save();
    }
}
