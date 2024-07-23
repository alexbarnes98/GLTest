using PurchaseHistory.Core.Entities;

namespace PurchaseHistory.Core.Interfaces;

public interface IPurchaseRepository
{
    IEnumerable<Purchase> GetPurchases();
    Purchase GetPurchase(long id);
}