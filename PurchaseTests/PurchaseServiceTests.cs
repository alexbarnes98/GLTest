namespace PurchaseHistory.Tests.Services;

public class PurchaseServiceTests
{
    private readonly Mock<ILogger<PurchaseService>> _mockLogger;
    private readonly Mock<IPurchaseRepository> _mockPurchaseRepository;
    private readonly PurchaseService _service;

    public PurchaseServiceTests()
    {
        _mockPurchaseRepository = new Mock<IPurchaseRepository>();
        _mockLogger = new Mock<ILogger<PurchaseService>>();
        _service = new PurchaseService(_mockPurchaseRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetPurchases_ReturnsAllPurchases()
    {
        // Arrange
        _mockPurchaseRepository.Setup(repo => repo.GetPurchases()).Returns(GetSamplePurchases());

        // Act
        IEnumerable<Purchase> result = _service.GetPurchases();

        // Assert
        Assert.Equal(30, result.Count()); // Expecting 30 purchases based on the provided repository
    }

    [Fact]
    public void GetPurchase_ReturnsPurchaseById()
    {
        // Arrange
        Purchase purchase = GetSamplePurchases().First();
        _mockPurchaseRepository.Setup(repo => repo.GetPurchase(purchase.Id)).Returns(purchase);

        // Act
        Purchase result = _service.GetPurchase(purchase.Id);

        // Assert
        Assert.Equal(purchase.Name, result.Name);
    }

    [Fact]
    public void GetSummaryStatistics_ReturnsCorrectStatistics()
    {
        // Arrange
        _mockPurchaseRepository.Setup(repo => repo.GetPurchases()).Returns(GetSamplePurchases());

        // Act
        SummaryStatistics result = _service.GetSummaryStatistics();

        // Assert
        Assert.Equal("2023-01", result.MostExpensiveMonth);
        Assert.Equal("2023-03", result.MonthWithMostUnitsBought);
        Assert.Equal("Azure SQL Database S9 1600 DTU", result.MostExpensivePurchaseProductName);
        Assert.Equal("D2 V3 Compute", result.ProductNameWithMostUnitsBought);
        Assert.Equal(388.84m, result.SpendPerMonth["2023-01"]);
        Assert.Equal(378.67m, result.SpendPerMonth["2023-02"]);
        Assert.Equal(354.79m, result.SpendPerMonth["2023-03"]);
    }

    private IEnumerable<Purchase> GetSamplePurchases()
    {
        return new List<Purchase>
        {
            new()
            {
                Id = 1, Name = "Block Blob Storage V2", PurchasedAt = new DateTime(2023, 1, 1), Quantity = 3,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 2, Name = "Power BI Embedded A5", PurchasedAt = new DateTime(2023, 1, 2), Quantity = 1,
                UnitPrice = 22.55m
            },
            new()
            {
                Id = 3, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 1, 4), Quantity = 4, UnitPrice = 7.95m
            },
            new()
            {
                Id = 4, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = new DateTime(2023, 1, 5), Quantity = 7,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 5, Name = "B1 App Service", PurchasedAt = new DateTime(2023, 1, 12), Quantity = 2,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 6, Name = "Azure Function C Tier", PurchasedAt = new DateTime(2023, 1, 15), Quantity = 2,
                UnitPrice = 22.55m
            },
            new()
            {
                Id = 7, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 1, 19), Quantity = 1,
                UnitPrice = 4.49m
            },
            new()
            {
                Id = 8, Name = "Power BI Embedded A5", PurchasedAt = new DateTime(2023, 1, 24), Quantity = 3,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 9, Name = "P1V2 App Service", PurchasedAt = new DateTime(2023, 1, 27), Quantity = 5,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 10, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 1, 28), Quantity = 2,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 11, Name = "Queue Storage GV2 LRS", PurchasedAt = new DateTime(2023, 2, 3), Quantity = 2,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 12, Name = "P1V2 App Service", PurchasedAt = new DateTime(2023, 2, 4), Quantity = 3,
                UnitPrice = 22.55m
            },
            new()
            {
                Id = 13, Name = "P2V2 App Service", PurchasedAt = new DateTime(2023, 2, 5), Quantity = 3,
                UnitPrice = 22.55m
            },
            new()
            {
                Id = 14, Name = "Power BI Embedded A3", PurchasedAt = new DateTime(2023, 2, 9), Quantity = 3,
                UnitPrice = 4.49m
            },
            new()
            {
                Id = 15, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 2, 11), Quantity = 3,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 16, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = new DateTime(2023, 2, 12), Quantity = 4,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 17, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 2, 14), Quantity = 5,
                UnitPrice = 7.95m
            },
            new()
            {
                Id = 18, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = new DateTime(2023, 2, 20), Quantity = 3,
                UnitPrice = 7.95m
            },
            new()
            {
                Id = 19, Name = "Azure Files", PurchasedAt = new DateTime(2023, 2, 21), Quantity = 3, UnitPrice = 7.95m
            },
            new()
            {
                Id = 20, Name = "Power BI Embedded A7", PurchasedAt = new DateTime(2023, 2, 26), Quantity = 2,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 21, Name = "D2 V3 Compute", PurchasedAt = new DateTime(2023, 3, 1), Quantity = 7,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 22, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 3, 3), Quantity = 2,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 23, Name = "Azure Function C Tier", PurchasedAt = new DateTime(2023, 3, 4), Quantity = 6,
                UnitPrice = 4.49m
            },
            new()
            {
                Id = 24, Name = "S1 App Service", PurchasedAt = new DateTime(2023, 3, 6), Quantity = 1,
                UnitPrice = 4.49m
            },
            new()
            {
                Id = 25, Name = "Block Blob Storage V2", PurchasedAt = new DateTime(2023, 3, 11), Quantity = 1,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 26, Name = "HC 44 Compute", PurchasedAt = new DateTime(2023, 3, 21), Quantity = 3,
                UnitPrice = 7.95m
            },
            new()
            {
                Id = 27, Name = "HX 176 Compute", PurchasedAt = new DateTime(2023, 3, 22), Quantity = 4,
                UnitPrice = 4.49m
            },
            new()
            {
                Id = 28, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = new DateTime(2023, 3, 23), Quantity = 3,
                UnitPrice = 12.95m
            },
            new()
            {
                Id = 29, Name = "S2 App Service", PurchasedAt = new DateTime(2023, 3, 26), Quantity = 1,
                UnitPrice = 22.55m
            },
            new()
            {
                Id = 30, Name = "Table Storage S LRS", PurchasedAt = new DateTime(2023, 3, 28), Quantity = 7,
                UnitPrice = 12.95m
            }
        };
    }
}