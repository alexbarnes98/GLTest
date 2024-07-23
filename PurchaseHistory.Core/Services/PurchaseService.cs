using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Core.Services
{
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
    }
}
