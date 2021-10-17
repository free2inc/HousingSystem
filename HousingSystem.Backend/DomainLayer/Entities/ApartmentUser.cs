namespace HousingSystem.DomainLayer.Entities
{
    public class ApartmentUser : BaseEntity
    {
        public int UserId { get; set; }
        User User { get; set; }
        public int ApartmentId { get; set; }
        Apartment Apartment { get; set; }

    }
}
