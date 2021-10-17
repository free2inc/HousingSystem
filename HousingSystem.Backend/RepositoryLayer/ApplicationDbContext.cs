//using DomainLayer.EntityMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Principal;
using DomainLayer.EntityMapper;
using HousingSystem.DomainLayer.Entities;


namespace RepositoryLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ApartmentUser> ApartmentUser { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ApartmentMap());
            //modelBuilder.ApplyConfiguration(new BuildingMap());

            base.OnModelCreating(modelBuilder);
            //ModelBuilderExtensions.Seed(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    CityAdminBuildingId = 101,
                    Number = "8D",
                    Address = "Some address 1",
                    Floors = 3,
                    District = "Some dist 1",
                    CreatedDate = DateTime.Now,
                },
                new Building
                {
                    Id = 2,
                    CityAdminBuildingId = 102,
                    Number = "8D",
                    Address = "Some address 2",
                    Floors = 4,
                    District = "Some dist 2",
                    CreatedDate = DateTime.Now,
                },
                new Building
                {
                    Id = 3,
                    CityAdminBuildingId = 101,
                    Number = "89",
                    Address = "Some address 3",
                    Floors = 1,
                    District = "Some dist 3",
                    CreatedDate = DateTime.Now,
                },
                new Building
                {
                    Id = 4,
                    CityAdminBuildingId = 101,
                    Number = "15A",
                    Address = "Some address 4",
                    Floors = 3,
                    District = "Some dist 4",
                    CreatedDate = DateTime.Now,
                });






            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    Id = 1,
                    NumberOfRooms = 3,
                    Area = 100,
                    Floor = 1,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                },
                new Apartment
                {
                    Id = 2,
                    NumberOfRooms = 3,
                    Area = 100,
                    Floor = 2,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                },
                new Apartment
                {
                    Id = 3,
                    NumberOfRooms = 3,
                    Area = 100,
                    Floor = 3,
                    BuildingId = 1,
                    CreatedDate = DateTime.Now,
                },
                new Apartment
                {
                    Id = 4,
                    NumberOfRooms = 1,
                    Area = 50,
                    Floor = 4,
                    BuildingId = 2,
                    CreatedDate = DateTime.Now,
                },
                new Apartment
                {
                    Id = 5,
                    NumberOfRooms = 4,
                    Area = 120,
                    Floor = 1,
                    BuildingId = 3,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}