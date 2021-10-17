namespace HousingSystem.DomainLayer.Entities
{
    public class Order : BaseEntity
    {
        public int PaymentId { get; set; }
        public int BuyerId { get; set; }
        private User Buyer { get; set; }
        public int SellerId { get; set; }
        private User Seller { get; set; }
        public int ApartmentId { get; set; }
        public decimal Price { get; set; }
        public int Floor { get; set; }


    }
}
