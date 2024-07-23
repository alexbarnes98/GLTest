using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Core.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public IEnumerable<Purchase> GetPurchases()
    {
        return _purchaseRepository.GetPurchases();
    }

    public Purchase GetPurchase(long id)
    {
        return _purchaseRepository.GetPurchase(id);
    }

    public SummaryStatistics GetSummaryStatistics()
    {
        IEnumerable<Purchase> purchases = _purchaseRepository.GetPurchases();

        Dictionary<string, decimal> spendPerMonth = purchases
            .GroupBy(p => p.PurchasedAt.ToString("yyyy-MM"))
            .ToDictionary(g => g.Key, g => g.Sum(p => p.Quantity * p.UnitPrice));

        string mostExpensiveMonth = spendPerMonth
            .OrderByDescending(s => s.Value)
            .First().Key;

        string monthWithMostUnitsBought = purchases
            .GroupBy(p => p.PurchasedAt.ToString("yyyy-MM"))
            .OrderByDescending(g => g.Sum(p => p.Quantity))
            .First().Key;

        string mostExpensivePurchaseProductName = purchases
            .OrderByDescending(p => p.Quantity * p.UnitPrice)
            .First().Name;

        string productNameWithMostUnitsBought = purchases
            .GroupBy(p => p.Name)
            .OrderByDescending(g => g.Sum(p => p.Quantity))
            .First().Key;

        return new SummaryStatistics
        {
            SpendPerMonth = spendPerMonth,
            MostExpensiveMonth = mostExpensiveMonth,
            MonthWithMostUnitsBought = monthWithMostUnitsBought,
            MostExpensivePurchaseProductName = mostExpensivePurchaseProductName,
            ProductNameWithMostUnitsBought = productNameWithMostUnitsBought
        };
    }
}