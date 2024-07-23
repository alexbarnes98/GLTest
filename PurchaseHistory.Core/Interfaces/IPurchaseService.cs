using PurchaseHistory.Core.Entities;

namespace PurchaseHistory.Core.Interfaces;

public interface IPurchaseService
{
    IEnumerable<Purchase> GetPurchases();
    Purchase GetPurchase(long id);
    SummaryStatistics GetSummaryStatistics();
}