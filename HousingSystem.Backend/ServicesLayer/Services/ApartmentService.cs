using System;
using System.Collections.Generic;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.DomainLayer.Interfaces;
using HousingSystem.ServicesLayer.Interfaces;

namespace ServicesLayer.Services
{
    public class ApartmentService : IApartmentService
    {
        #region Property  
        private IRepository<Apartment> _repository;
        private readonly Random _random = new Random();
        #endregion

        #region Constructor  
        public ApartmentService(IRepository<Apartment> repository)
        {
            _repository = repository;
        }
        #endregion

        public IEnumerable<Apartment> GetAllApartments()
        {
            return _repository.GetAll();
        }

        public Apartment GetApartment(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var apartment = new Apartment();
            
            try
            {
                apartment = _repository.Get(id);
            }
            catch (Exception ex)
            {
                throw new();

            }

            return apartment;
        }

        public void CreateApartment(Apartment Apartment)
        {
            _repository.Create(Apartment);
        }

        public void CreateApartments(int buildingId, int numberOfApartments)
        {
            for (int i = 0; i < numberOfApartments; i++)
            {
                var apartment = new Apartment()
                {
                    BuildingId = buildingId,
                    Floor = i++,
                    Area = (float)RandomNumber(80, 200),
                    NumberOfRooms = RandomNumber(1, 5),
                    CreatedDate = DateTime.Now
                };

                _repository.Create(apartment);
            }
        }

        
        public void UpdateApartment(Apartment apartment)
        {
            _repository.Update(apartment);
        }

        public void DeleteApartment(int id)
        {
            Apartment Apartment = GetApartment(id);
            _repository.Remove(Apartment);
            _repository.SaveChanges();
        }

        public void UpdateApartmentWithodBuildingId(Apartment apartment)
        {
            var oldApartment = GetApartment(apartment.Id);

            oldApartment.Area = apartment.Area;
            oldApartment.Floor = apartment.Floor;
            oldApartment.NumberOfRooms = apartment.NumberOfRooms;

            UpdateApartment(oldApartment);

        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
