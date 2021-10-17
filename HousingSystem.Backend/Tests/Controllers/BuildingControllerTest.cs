using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HousingSystem.Controllers;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.Dto.Building;
using HousingSystem.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ServicesLayer.Interfaces;
using ServicesLayer.Models;
using Xunit;

namespace HousingSystem.Tests.Controllers
{
    public class BuildingControllerTest
    {

        [Fact]
        public async Task GetAllBuildingsStatusCode()
        {
            // Arrange
            var buildingServiceMock = new Mock<IBuildingService>();
            buildingServiceMock.Setup(service => service.GetFreeBuildings()).ReturnsAsync(GetTestCitizenBuildings());

            var logMock = new Mock<ILogger<Building>>();

            var controller = new BuildingController(buildingServiceMock.Object, logMock.Object);


            var citizenBuildings = new List<BuildingModel>
            {
                new BuildingModel()
                {
                    Id = 12,
                    Name = null,
                    FloorCount = 3,
                    Street = "TestStreet",
                    Number = 9
                },
                new BuildingModel()
                {
                    Id = 12,
                    Name = null,
                    FloorCount = 3,
                    Street = "TestStreet",
                    Number = 9
                }

            };

            // Act
            var result = await controller.GetAllFreeBuildings();
            var okResult = result as OkObjectResult;

            var viewResult = Assert.IsType<OkObjectResult>(result);
            //var some2 = Assert.
            //var model = Assert.IsAssignableFrom<IEnumerable<BuildingModel>>(viewResult.Value);

            // Assert
            //Assert.Equal(citizenBuildings.Count, model.AsEnumerable().Count());
            Assert.Equal(200, okResult?.StatusCode);
        }



        private IList<BuildingModel> GetTestCitizenBuildings()
        {
            var citizenBuildings = new List<BuildingModel>
            {
                new BuildingModel()
                {
                    Id = 12,
                    Name = null,
                    FloorCount = 3,
                    Street = "TestStreet",
                    Number = 9
                },
                new BuildingModel()
                {
                    Id = 12,
                    Name = null,
                    FloorCount = 3,
                    Street = "TestStreet",
                    Number = 9
                }
                
            };
            return citizenBuildings;
        }

         


        [Fact]
        public void CreateBuilding()
        {

            //Arrange

           var buildingDto = new CreateBuildingDto()
           {
               CityAdminBuildingId = 1,
               Number = "abc",
               Floors = 2,
               District = "district",
               Address = "address"
           };

            var buildingServiceMock = new Mock<IBuildingService>();
            buildingServiceMock.Setup(service => service.ReserveBuilding(buildingDto.CityAdminBuildingId)).ReturnsAsync(true);
            buildingServiceMock.Setup(service => service.CreateBuilding(new Building()));

            var logMock = new Mock<ILogger<Building>>();


            var controller = new BuildingController(buildingServiceMock.Object, logMock.Object);

            // Act
            var result = controller.CreateBuilding(buildingDto);
            var okResult = result as OkObjectResult;

            var viewResult = Assert.IsType<OkObjectResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<BuildingModel>>(viewResult.Value);

            // Assert
            //Assert.Equal("", result?.ViewData["Message"]);
            Assert.Equal("Data inserted", viewResult.Value);
        }




        private IList<Building> CreateBuildings()
        {
            var buildings = new List<Building>()
            {
                new Building()
                {
                    Id = 1,
                    Address = "Address",
                    CityAdminBuildingId = 111,
                    CreatedDate = DateTime.Now,
                    District = "Dist",
                    Floors = 3,
                    Number = "123"
                },
                new Building()
                {
                    Id = 2,
                    Address = "Address",
                    CityAdminBuildingId = 222,
                    CreatedDate = DateTime.Now,
                    District = "Dist",
                    Floors = 4,
                    Number = "123as"
                },
                new Building()
                {
                    Id = 3,
                    Address = "Address",
                    CityAdminBuildingId = 333,
                    CreatedDate = DateTime.Now,
                    District = "Dist",
                    Floors = 5,
                    Number = "123qwe"
                },


            };
            return buildings;

        }



    }
}
