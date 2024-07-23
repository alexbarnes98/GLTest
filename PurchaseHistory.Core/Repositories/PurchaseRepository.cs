using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Core.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly IEnumerable<Purchase> _purchases = new List<Purchase>
    {
        new()
        {
            Id = 1, Name = "Block Blob Storage V2", PurchasedAt = new DateTime(2023, 1, 1), Quantity = 3,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 2, Name = "Power BI Embedded A5", PurchasedAt = new DateTime(2023, 1, 2), Quantity = 1,
            UnitPrice = 22.55m, Description = "Description"
        },
        new()
        {
            Id = 3, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 1, 4), Quantity = 4, UnitPrice = 7.95m,
            Description = "Description"
        },
        new()
        {
            Id = 4, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = new DateTime(2023, 1, 5), Quantity = 7,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 5, Name = "B1 App Service", PurchasedAt = new DateTime(2023, 1, 12), Quantity = 2, UnitPrice = 12.95m,
            Description = "Description"
        },
        new()
        {
            Id = 6, Name = "Azure Function C Tier", PurchasedAt = new DateTime(2023, 1, 15), Quantity = 2,
            UnitPrice = 22.55m, Description = "Description"
        },
        new()
        {
            Id = 7, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 1, 19), Quantity = 1,
            UnitPrice = 4.49m, Description = "Description"
        },
        new()
        {
            Id = 8, Name = "Power BI Embedded A5", PurchasedAt = new DateTime(2023, 1, 24), Quantity = 3,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 9, Name = "P1V2 App Service", PurchasedAt = new DateTime(2023, 1, 27), Quantity = 5,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 10, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 1, 28), Quantity = 2, UnitPrice = 12.95m,
            Description = "Description"
        },
        new()
        {
            Id = 11, Name = "Queue Storage GV2 LRS", PurchasedAt = new DateTime(2023, 2, 3), Quantity = 2,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 12, Name = "P1V2 App Service", PurchasedAt = new DateTime(2023, 2, 4), Quantity = 3,
            UnitPrice = 22.55m, Description = "Description"
        },
        new()
        {
            Id = 13, Name = "P2V2 App Service", PurchasedAt = new DateTime(2023, 2, 5), Quantity = 3,
            UnitPrice = 22.55m, Description = "Description"
        },
        new()
        {
            Id = 14, Name = "Power BI Embedded A3", PurchasedAt = new DateTime(2023, 2, 9), Quantity = 3,
            UnitPrice = 4.49m, Description = "Description"
        },
        new()
        {
            Id = 15, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 2, 11), Quantity = 3, UnitPrice = 12.95m,
            Description = "Description"
        },
        new()
        {
            Id = 16, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = new DateTime(2023, 2, 12), Quantity = 4,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 17, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 2, 14), Quantity = 5,
            UnitPrice = 7.95m, Description = "Description"
        },
        new()
        {
            Id = 18, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = new DateTime(2023, 2, 20), Quantity = 3,
            UnitPrice = 7.95m, Description = "Description"
        },
        new()
        {
            Id = 19, Name = "Azure Files", PurchasedAt = new DateTime(2023, 2, 21), Quantity = 3, UnitPrice = 7.95m,
            Description = "Description"
        },
        new()
        {
            Id = 20, Name = "Power BI Embedded A7", PurchasedAt = new DateTime(2023, 2, 26), Quantity = 2,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 21, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 3, 1), Quantity = 7, UnitPrice = 12.95m,
            Description = "Description"
        },
        new()
        {
            Id = 22, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 3, 3), Quantity = 2, UnitPrice = 12.95m,
            Description = "Description"
        },
        new()
        {
            Id = 23, Name = "Azure Function C Tier", PurchasedAt = new DateTime(2023, 3, 4), Quantity = 6,
            UnitPrice = 4.49m, Description = "Description"
        },
        new()
        {
            Id = 24, Name = "S1 App Service", PurchasedAt = new DateTime(2023, 3, 6), Quantity = 1, UnitPrice = 4.49m,
            Description = "Description"
        },
        new()
        {
            Id = 25, Name = "Block Blob Storage V2", PurchasedAt = new DateTime(2023, 3, 11), Quantity = 1,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 26, Name = "HC 44 Compute", PurchasedAt = new DateTime(2023, 3, 21), Quantity = 3, UnitPrice = 7.95m,
            Description = "Description"
        },
        new()
        {
            Id = 27, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 3, 22), Quantity = 4, UnitPrice = 4.49m,
            Description = "Description"
        },
        new()
        {
            Id = 28, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = new DateTime(2023, 3, 23), Quantity = 3,
            UnitPrice = 12.95m, Description = "Description"
        },
        new()
        {
            Id = 29, Name = "S2 App Service", PurchasedAt = new DateTime(2023, 3, 26), Quantity = 1, UnitPrice = 22.55m,
            Description = "Description"
        },
        new()
        {
            Id = 30, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 3, 28), Quantity = 7,
            UnitPrice = 12.95m, Description = "Description"
        }
    };

    public IEnumerable<Purchase> GetPurchases()
    {
        return _purchases.ToList();
    }

    public Purchase GetPurchase(long id)
    {
        return _purchases.SingleOrDefault(p => p.Id == id);
    }
}