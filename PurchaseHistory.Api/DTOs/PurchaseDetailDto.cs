namespace PurchaseHistory.Api.DTOs;

public class PurchaseDetailDto
{
    public string Name { get; set; }
    public DateTime PurchasedAt { get; set; }
    public decimal Cost { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Description { get; set; }
}