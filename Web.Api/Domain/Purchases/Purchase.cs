namespace Web.Api.Entities.Purchases
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public DateTime PuchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<PurchaseItem> Items { get; set; }
    }
}
