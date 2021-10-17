using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Dtos;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.Dto.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ServicesLayer.Interfaces;
using CreateBuildingDto = HousingSystem.Dto.Building.CreateBuildingDto;

namespace HousingSystem.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        #region Property  
        private readonly IApartmentService _apartmentService;
        private readonly ILogger<Apartment> _logger;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor  
        public ApartmentController(IApartmentService apartmentService, ILogger<Apartment> logger, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        [HttpGet(nameof(GetApartment))]
        public IActionResult GetApartment(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Validation failed. Id Cannot be less or equal 0.");
                return BadRequest("Validation failed. Id Cannot be less or equal 0");
            }

            var result = new Apartment();

            try
            {
                //var apartment = _apartmentService.GetApartment(id);
                //result = _mapper.Map<>(apartment);
                result = _apartmentService.GetApartment(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetApartment({id}) error.", ex);
                return BadRequest("No records found");
            }
            
            return Ok(result);
        }
        [HttpGet(nameof(GetAllApartment))]
        public IActionResult GetAllApartment()
        {
            var result = _apartmentService.GetAllApartments();
            if (result is not null)
            {
                _logger.LogInformation($"Get All Apartment: {result.ToList()}");
                return Ok(result);
            }
            _logger.LogError($"Error in Get All Apartment: {result.ToList()}");
            return BadRequest("No records found");

        }



        [HttpPost(nameof(CreateApartment))]
        public IActionResult CreateApartment([FromBody] ICreateApartmentDto apartmentDto)
        {
            var apartment = new Apartment()
            {
                Area = apartmentDto.Area,
                BuildingId = apartmentDto.BuildingId,
                CreatedDate = DateTime.Now,
                Floor = apartmentDto.Floor,
                NumberOfRooms = apartmentDto.NumberOfRooms
            };
            _apartmentService.CreateApartment(apartment);
            return Ok("Data inserted");

        }



        [HttpPut(nameof(UpdateApartment))]
        public IActionResult UpdateApartment(ICreateApartmentDto apartmentDto)
        {

            var some = apartmentDto;

            //var apartment = _mapper.Map<CreateBuildingDto, Apartment>(apartmentDto);

            //_apartmentService.UpdateApartmentWithodBuildingId(apartment);
            return Ok("Updation done");

        }

        //[HttpDelete(nameof(DeleteApartment))]
        //public IActionResult DeleteApartment(int Id)
        //{
        //    _apartmentService.DeleteApartment(Id);
        //    return Ok("Data Deleted");

        //}
    }
}
