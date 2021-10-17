﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos
{
    class ApartmentDto
    {
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
    }

    public interface ICreateApartmentDto
    {
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
        public int BuildingId { get; set; }
    }

    public class CreateApartmentDto : ICreateApartmentDto
    {
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
        public int BuildingId { get; set; }
    }

    public class CreateApartment2Dto : ICreateApartmentDto
    {
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
        public int BuildingId { get; set; }
        public int Some { get; set; }
    }

    public class EditApartmentDto
    {
        public int Id { get; set; }
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
    }

    public class DeleteApartmentDto
    {
        public int Id { get; set; }
        
    }
}
