using System;
using System.Collections.Generic;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.DomainLayer.Interfaces;
using HousingSystem.ServicesLayer.Interfaces;
using HousingSystem.ServicesLayer.Services;
using Microsoft.Extensions.Logging;
using Moq;
using ServicesLayer.Services;
using Xunit;

namespace HousingSystem.Tests.Services
{
    public class ApartmentServiceTest
    {
        private readonly IBuildingService _buildingService;
        private readonly Mock<IRepository<Building>> _buildingRepositoryMock;
        private readonly Mock<ILogger<Building>> _logMock;
        private readonly Mock<IApartmentService> _apartmentService;
        private readonly Mock<IRepository<Apartment>> _apartmentRepositoryMock;



        public ApartmentServiceTest()
        {
            _buildingRepositoryMock = new Mock<IRepository<Building>>();
            _logMock = new Mock<ILogger<Building>>();
            _apartmentRepositoryMock = new Mock<IRepository<Apartment>>();
            _apartmentService = new Mock<IApartmentService>();
            _buildingService = new BuildingService(_buildingRepositoryMock.Object, _logMock.Object, _apartmentService.Object);
        }
        
        //[Fact]
        //public void GetApartment_ReturnNotNull()
        //{
        //    //var building = CreateBuildings()[0];
        //    //_buildingRepositoryMock.Setup(repo => repo.Get(building.Id)).Returns(building);

        //    var result = _buildingService.GetBuilding(1);
        //    Assert.NotNull(result);
        //    Assert.IsType<Building>(result);
        //}

        //[Fact]
        //public void GetBuilding_ReturnNull()
        //{
        //    var building = CreateBuildings()[0];
        //    _buildingRepositoryMock.Setup(repo => repo.Get(1)).Returns((Building)null);

        //    var result = _buildingService.GetBuilding(1);
        //    Assert.Null(result);
        //}

        //[Fact]
        //public void GetBuilding_OnlyOnce()
        //{
        //    _buildingRepositoryMock.Setup(repo => repo.Get(1)).Returns(new Building());

        //    var result = _buildingService.GetBuilding(1);
        //    _buildingRepositoryMock.Verify(mock => mock.Get(1), Times.Once);
        //}

        //[Fact]
        //public void GetAllBuildings_ReturnNotNull()
        //{
        //    var building = CreateBuildings();
        //    _buildingRepositoryMock.Setup(repo => repo.GetAll()).Returns(building);

        //    var result = _buildingService.GetAllBuildings();
        //    Assert.NotNull(result);
        //    Assert.IsType<List<Building>>(result);
        //}

        //[Fact]
        //public void GetAllBuildings_ReturnNull()
        //{
        //    var building = CreateBuildings();
        //    _buildingRepositoryMock.Setup(repo => repo.GetAll()).Returns((List<Building>)null);

        //    var result = _buildingService.GetAllBuildings();
        //    Assert.Null(result);
        //}

        //[Fact]
        //public void GetAllBuildings_EqualToExpected()
        //{
        //    var building = CreateBuildings();
        //    _buildingRepositoryMock.Setup(repo => repo.GetAll()).Returns(building);

        //    var result = _buildingService.GetAllBuildings();
        //    Assert.Equal(building.ToString(), result.ToString());
        //}

        //[Fact]
        //public void UpdateBuilding_ShouldCallCreateFromRepository_OnlyOnce()
        //{
        //    var building = CreateBuildings()[0];

        //    _buildingService.UpdateBuilding(building);

        //    _buildingRepositoryMock.Verify(mock => mock.Update(building), Times.Once);
        //}

        //[Fact]
        //public void CreateBuilding_ShouldCallCreateFromRepository_OnlyOnce()
        //{
        //    var building = CreateBuildings()[0];

        //    _buildingService.CreateBuilding(building);

        //    _buildingRepositoryMock.Verify(mock => mock.Create(building), Times.Once);
        //}


        //private IList<Building> CreateBuildings()
        //{
        //    var buildings = new List<Building>()
        //    {
        //        new Building()
        //        {
        //            Id = 1,
        //            Address = "Address",
        //            CityAdminBuildingId = 111,
        //            CreatedDate = DateTime.Now,
        //            District = "Dist",
        //            Floors = 3,
        //            Number = "123"
        //        },
        //        new Building()
        //        {
        //            Id = 2,
        //            Address = "Address",
        //            CityAdminBuildingId = 222,
        //            CreatedDate = DateTime.Now,
        //            District = "Dist",
        //            Floors = 4,
        //            Number = "123as"
        //        },
        //        new Building()
        //        {
        //            Id = 3,
        //            Address = "Address",
        //            CityAdminBuildingId = 333,
        //            CreatedDate = DateTime.Now,
        //            District = "Dist",
        //            Floors = 5,
        //            Number = "123qwe"
        //        },


        //    };
        //    return buildings;

        //}
    }
}
