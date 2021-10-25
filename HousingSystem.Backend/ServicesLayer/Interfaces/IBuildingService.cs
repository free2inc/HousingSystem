using System.Collections.Generic;
using System.Threading.Tasks;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.ServicesLayer.Models;

namespace HousingSystem.ServicesLayer.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetAllBuildings();
        Building GetBuilding(int id);
        void CreateBuilding(Building building);
        void UpdateBuilding(Building building);
        void DeleteBuilding(int id);

        public Task<IList<BuildingModel>> GetFreeBuildings();
        public Task<bool> ReserveBuilding(int id);
    }
}
