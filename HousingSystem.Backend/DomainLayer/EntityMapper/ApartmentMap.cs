using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingSystem.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class ApartmentMap : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            //builder.Property(x => x.Id).ValueGeneratedOnAdd()
            //    .HasColumnName("id")
            //    .HasColumnType("INT");
            //builder.Property(x => x.BuildingId)
            //    .HasColumnName("BuildingId")
            //    .HasColumnType("INT")
            //    .IsRequired();
            //builder.Property(x => x.NumberOfRooms)
            //    .HasColumnName("NumberOfRooms")
            //    .HasColumnType("INT")
            //    .IsRequired();
            //builder.Property(x => x.Area)
            //    .HasColumnName("Area")
            //    .HasColumnType("float")
            //    .IsRequired();
            //builder.Property(x => x.Floor)
            //    .HasColumnName("Floor")
            //    .HasColumnType("INT")
            //    .IsRequired();
            //builder.Property(x => x.CreatedDate)
            //    .HasColumnName("CreatedDate")
            //    .HasColumnType("datetime");
            //builder.Property(x => x.ModifiedDate)
            //    .HasColumnName("ModifiedDate")
            //    .HasColumnType("datetime");
        }
    }
}
