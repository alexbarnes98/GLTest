namespace PurchaseHistory.Api.DTOs {
    public class PurchaseDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime PurchasedAt { get; set; }
        public decimal TotalCost { get; set; }
    }
}
