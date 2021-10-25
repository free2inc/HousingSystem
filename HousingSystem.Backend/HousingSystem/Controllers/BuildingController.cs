using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.Dto.Building;
using HousingSystem.ServicesLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace HousingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        #region Property  
        private readonly IBuildingService _buildingService;
        private readonly ILogger<Building> _logger;
        //private readonly IMapper _mapper;
        #endregion

        #region Constructor  
        public BuildingController(IBuildingService buildingService, ILogger<Building> logger/*, IMapper mapper*/)
        {
            _buildingService = buildingService;
            _logger = logger;
            //_mapper = mapper;
        }
        #endregion

        [HttpGet(nameof(GetBuilding))]
        public IActionResult GetBuilding(int id)
        {
            var result = _buildingService.GetBuilding(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpGet(nameof(GetAllBuilding))]
        public IActionResult GetAllBuilding()
        {
            var result = _buildingService.GetAllBuildings();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        
        [HttpPut(nameof(UpdateBuilding))]
        public IActionResult UpdateBuilding(Building building)
        {
            _buildingService.UpdateBuilding(building);
            return Ok("Updation done");

        }
        [HttpDelete(nameof(DeleteBuilding))]
        public IActionResult DeleteBuilding(int Id)
        {
            _buildingService.DeleteBuilding(Id);
            return Ok("Data Deleted");

        }


        [HttpGet(nameof(GetAllFreeBuildings))]
        public async Task<IActionResult> GetAllFreeBuildings()
        {
            var buildings = await _buildingService.GetFreeBuildings();
            return Ok(buildings);
        }


        [HttpPost(nameof(CreateBuilding))]
        public IActionResult CreateBuilding(CreateBuildingDto buildingDto)
        {
            try
            {
                //if (_buildingService.ReserveBuilding(buildingDto.CityAdminBuildingId).Result)
                {
                    var building = new Building()
                    {
                        CityAdminBuildingId = buildingDto.CityAdminBuildingId,
                        Number = buildingDto.Number,
                        Floors = buildingDto.Floors,
                        District = buildingDto.District,
                        Address = buildingDto.Address,
                        CreatedDate = DateTime.Now

                    };

                    _buildingService.CreateBuilding(building);


                    return Ok("Data inserted");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"CreateBuilding error.", ex);
                throw new Exception("Error in reserving building");
            }

            return Ok("Data inserted");

        }
    }
}
