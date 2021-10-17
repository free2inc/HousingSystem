using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos
{
    public class GetBuildingDto
    {
        public int CityAdminBuildingId { get; set; }
        public string Number { get; set; }
        public int Floors { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }

    //public class CreateBuildingDto
    //{
    //    public int CityAdminBuildingId { get; set; }
    //    public string Number { get; set; }
    //    public int Floors { get; set; }
    //    public string District { get; set; }
    //    public string Address { get; set; }
    //}

    public class EditBuildingDto
    {
        public int Id { get; set; }
        public int CityAdminBuildingId { get; set; }
        public string Number { get; set; }
        public int Floors { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }

    public class DeleteBuildingDto
    {
        public int Id { get; set; }
        
    }
}
