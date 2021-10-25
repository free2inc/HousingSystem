namespace HousingSystem.DomainLayer.Entities
{
    public class Order : BaseEntity
    {
        public int PaymentId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ApartmentId { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }


    }
}
