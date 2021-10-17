using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingSystem.Dto.Apartment
{
    public class CreateBuildingDto 
    {
        public int Id { get; set; }
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }
    }
}
