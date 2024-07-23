using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseHistory.Core.Entities {
    public class Purchase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime PurchasedAt { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}
