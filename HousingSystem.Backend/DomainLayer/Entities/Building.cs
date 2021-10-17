namespace HousingSystem.DomainLayer.Entities
{
    public class Building : BaseEntity
    {
        public int CityAdminBuildingId { get; set; }
        public string Number { get; set; }
        public int Floors { get; set; }
        public string District { get; set; }
        public string Address { get; set; }

    }
}
