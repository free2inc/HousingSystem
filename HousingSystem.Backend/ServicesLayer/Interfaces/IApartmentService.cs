using System.Collections.Generic;
using HousingSystem.DomainLayer.Entities;

namespace HousingSystem.ServicesLayer.Interfaces
{
    public interface IApartmentService
    {
        IEnumerable<Apartment> GetAllApartments();
        Apartment GetApartment(int id);
        void CreateApartment(Apartment apartment);
        public void CreateApartments(int BuildingId, int numberOfApartments);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(int id);
        void UpdateApartmentWithodBuildingId(Apartment apartment);
    }
}
