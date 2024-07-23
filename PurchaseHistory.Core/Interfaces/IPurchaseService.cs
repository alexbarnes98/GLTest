using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseHistory.Core.Entities;

namespace PurchaseHistory.Core.Interfaces {
    public interface IPurchaseService {
        IEnumerable<Purchase> GetPurchases();

    }
}
