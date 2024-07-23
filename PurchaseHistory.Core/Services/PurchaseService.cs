using Microsoft.Extensions.Logging;
using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Core.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ILogger<PurchaseService> _logger;

        public PurchaseService(IPurchaseRepository purchaseRepository, ILogger<PurchaseService> logger)
        {
            _purchaseRepository = purchaseRepository;
            _logger = logger;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            try
            {
                _logger.LogInformation("Fetching all purchases from repository");
                return _purchaseRepository.GetPurchases();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching purchases");
                throw;
            }
        }

        public Purchase GetPurchase(long id)
        {
            try
            {
                _logger.LogInformation("Fetching purchase with id: {Id} from repository", id);
                return _purchaseRepository.GetPurchase(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching purchase with id: {Id}", id);
                throw;
            }
        }

        public SummaryStatistics GetSummaryStatistics()
        {
            try
            {
                _logger.LogInformation("Calculating summary statistics");

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calculating summary statistics");
                throw;
            }
        }
    }
}
