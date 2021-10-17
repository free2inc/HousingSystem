namespace HousingSystem.DomainLayer.Entities
{
    public class Apartment : BaseEntity
    {
        public int NumberOfRooms { get; set; }
        public float Area { get; set; }
        public int Floor { get; set; }


        public int BuildingId { get; set; }
        Building Building { get; set; }
    }
}
