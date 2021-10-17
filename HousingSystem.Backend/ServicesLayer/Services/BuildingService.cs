using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.DomainLayer.Interfaces;
using HousingSystem.ServicesLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServicesLayer.Interfaces;
using ServicesLayer.Models;

namespace HousingSystem.ServicesLayer.Services
{
    public class BuildingService : IBuildingService
    {
        #region Property  
        private IRepository<Building> _buildingRepository;
        private IApartmentService _apartmentService;
        private readonly ILogger<Building> _logger;

        private const string URI = "https://cityadministration20210925021624.azurewebsites.net//api/Building/";
        #endregion

        #region Constructor  
        public BuildingService(IRepository<Building> buildingRepository, ILogger<Building> logger, IApartmentService apartmentService)
        {
            _buildingRepository = buildingRepository;
            _logger = logger;
            _apartmentService = apartmentService;
        }
        #endregion

        public IEnumerable<Building> GetAllBuildings()
        {
            return _buildingRepository.GetAll();
        }

        public Building GetBuilding(int id)
        {
            return _buildingRepository.Get(id);
        }

        public void CreateBuilding(Building building)
        {
            var buildingId = _buildingRepository.Create(building);

            _apartmentService.CreateApartments(buildingId, building.Floors);
        }
        public void UpdateBuilding(Building building)
        {
            _buildingRepository.Update(building);
        }

        public void DeleteBuilding(int id)
        {
            Building Building = GetBuilding(id);
            _buildingRepository.Remove(Building);
            _buildingRepository.SaveChanges();
        }

        public async Task<IList<BuildingModel>> GetFreeBuildings()
        {
            var buildings = new List<BuildingModel>();


            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = new HttpResponseMessage();


                try
                {
                    var uri = URI + "GetFreeBuildings";
                    response = await client.GetAsync(uri);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Cannot get request from Citizen Project. Error: {e.Message}");
                    throw new HttpRequestException($"Cannot get request from Citizen Project. {e}");
                }


                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    buildings = (List<BuildingModel>)JsonConvert.DeserializeObject<IList<BuildingModel>>(jsonString);

                    return buildings;

                }
                else
                {
                    var errorResponse = response.Content.ReadAsStringAsync().Result;
                    _logger.LogError($"response status in {response.StatusCode}. Response: {errorResponse}");
                }

            }
            return buildings;
        }

        public async Task<bool> ReserveBuilding(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(URI + $"/ReserveBuilding?id={id}&newBuildingType=4", null);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Cannot get request from Citizen Project ReserveBuilding method. Error: {e.Message}");
                    throw new HttpRequestException($"Cannot get request from Citizen Project ReserveBuilding method. {e}");
                }

                if (response.IsSuccessStatusCode)
                    return true;

                var errorResponse = response.Content.ReadAsStringAsync().Result;
                _logger.LogError($"Error sending owner request: response code: {response.StatusCode}, response: {errorResponse}");
            }

            return false;
        }
    }
}
