namespace PurchaseHistory.Core.Entities;

public class SummaryStatistics
{
    public Dictionary<string, decimal> SpendPerMonth { get; set; }
    public string MostExpensiveMonth { get; set; }
    public string MonthWithMostUnitsBought { get; set; }
    public string MostExpensivePurchaseProductName { get; set; }
    public string ProductNameWithMostUnitsBought { get; set; }
}