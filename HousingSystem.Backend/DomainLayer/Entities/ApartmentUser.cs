namespace HousingSystem.DomainLayer.Entities
{
    public class ApartmentUser : BaseEntity
    {
        public int UserId { get; set; }
        public int ApartmentId { get; set; }

    }
}
