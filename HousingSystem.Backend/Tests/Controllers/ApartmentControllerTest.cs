using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using DomainLayer.Dtos;
using HousingSystem.Controllers;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.ServicesLayer.Interfaces;
using HousingSystem.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HousingSystem.Tests.Controllers
{
    public class ApartmentControllerTest
    {
        private readonly ApartmentController _apartmentController;
        readonly Mock<IApartmentService> _serviceMock;
        readonly Mock<ILogger<Apartment>> _logMock;
        readonly Mock<IMapper> _mapperMock;

        public ApartmentControllerTest()
        {
            _serviceMock = new Mock<IApartmentService>();
            _logMock = new Mock<ILogger<Apartment>>();
            _mapperMock = new Mock<IMapper>();
            _apartmentController = new ApartmentController(_serviceMock.Object, _logMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetAllApartments()
        {
            // Arrange
            _serviceMock.Setup(service => service.GetAllApartments()).Returns(GetTestApartments());

            var apartments = new List<Apartment>
            {
                new Apartment()
                {
                    Id=1,
                    Floor = 1,
                    Area = 100,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                    NumberOfRooms = 2
                },

            };


            // Act
            var result = _apartmentController.GetAllApartment();
            var okResult = result as OkObjectResult;
            // Assert

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Apartment>>(viewResult.Value);
            //Assert.Equal(200, okResult.StatusCode);
            //Assert.Equal(apartments, okResult?.Value );
            Assert.Equal(apartments.Count, model.AsEnumerable().Count());
            Assert.Equal(apartments.ToString(), okResult.Value.ToString());
        }

        [Fact]
        public void GetApartment_ID_lessThanZero()
        {
            var result = _apartmentController.GetApartment(-1) as BadRequestObjectResult;
            Assert.Equal(400, result?.StatusCode );
        }

        [Fact]
        public void GetApartment_ShouldReturnOk_WhenApartmentExist()
        {
            var apartment = GetTestApartments()[0];

            _serviceMock.Setup(mock => mock.GetApartment(apartment.Id)).Returns(apartment);
            var result = _apartmentController.GetApartment(apartment.Id) as OkObjectResult;

            Assert.Equal(apartment, result?.Value);
        }

        [Fact]
        public void CreateApartment_ShouldReturnOk_WhenApartmentExist()
        {
            var apartment = GetTestApartments()[0];


            _serviceMock.Setup(mock => mock.CreateApartment(apartment));
            var result = _apartmentController.CreateApartment(new CreateApartmentDto()) as OkObjectResult;

            Assert.Equal("Data inserted", result?.Value);
        }







        private List<Apartment> GetTestApartments()
        {
            var users = new List<Apartment>
            {
                new Apartment()
                {
                    Id=1, 
                    Floor = 4,
                    Area = 100,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                    NumberOfRooms = 2
                },
                new Apartment()
                {
                    Id=2,
                    Floor = 3,
                    Area = 100,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                    NumberOfRooms = 2
                },
                new Apartment()
                {
                    Id=3,
                    Floor = 1,
                    Area = 52,
                    BuildingId = 4,
                    CreatedDate = DateTime.Now,
                    NumberOfRooms = 2
                },
                new Apartment()
                {
                    Id=4,
                    Floor = 6,
                    Area = 120,
                    BuildingId = 2,
                    CreatedDate = DateTime.Now,
                    NumberOfRooms = 5
                },

            };
            return users;
        }
    }
}
