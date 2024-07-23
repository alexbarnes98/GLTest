using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PurchaseHistory.Api.Controllers;
using PurchaseHistory.Api.DTOs;
using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace PurchaseHistory.Tests.Controllers;

public class PurchaseControllerTests
{
    private readonly PurchaseController _controller;
    private readonly Mock<ILogger<PurchaseController>> _mockLogger;
    private readonly Mock<IPurchaseService> _mockPurchaseService;

    public PurchaseControllerTests()
    {
        _mockPurchaseService = new Mock<IPurchaseService>();
        _mockLogger = new Mock<ILogger<PurchaseController>>();
        _controller = new PurchaseController(_mockPurchaseService.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetAllPurchases_ReturnsOkResult_WithListOfPurchases()
    {
        // Arrange
        _mockPurchaseService.Setup(service => service.GetPurchases()).Returns(GetSamplePurchases());

        // Act
        ActionResult<IEnumerable<PurchaseDto>> result = _controller.GetAllPurchases();

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
        List<PurchaseDto> returnValue = Assert.IsType<List<PurchaseDto>>(okResult.Value);
        Assert.Equal(30, returnValue.Count); // Expecting 30 purchases based on the provided repository
    }

    [Fact]
    public void GetPurchaseById_ReturnsOkResult_WithPurchaseDetail()
    {
        // Arrange
        Purchase purchase = GetSamplePurchases().First();
        _mockPurchaseService.Setup(service => service.GetPurchase(purchase.Id)).Returns(purchase);

        // Act
        ActionResult<PurchaseDetailDto> result = _controller.GetPurchaseById(purchase.Id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
        PurchaseDetailDto returnValue = Assert.IsType<PurchaseDetailDto>(okResult.Value);
        Assert.Equal(purchase.Name, returnValue.Name);
    }

    [Fact]
    public void GetPurchaseById_ReturnsNotFound_WhenPurchaseDoesNotExist()
    {
        // Arrange
        _mockPurchaseService.Setup(service => service.GetPurchase(It.IsAny<long>())).Returns((Purchase)null);

        // Act
        ActionResult<PurchaseDetailDto> result = _controller.GetPurchaseById(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void GetSummaryStatistics_ReturnsOkResult_WithStatistics()
    {
        // Arrange
        SummaryStatistics statistics = new()
        {
            SpendPerMonth = new Dictionary<string, decimal>
            {
                { "2023-01", 388.84m },
                { "2023-02", 378.67m },
                { "2023-03", 354.79m }
            },
            MostExpensiveMonth = "2023-01",
            MonthWithMostUnitsBought = "2023-03",
            MostExpensivePurchaseProductName = "Azure SQL Database S9 1600 DTU",
            ProductNameWithMostUnitsBought = "D2 V3 Compute"
        };
        _mockPurchaseService.Setup(service => service.GetSummaryStatistics()).Returns(statistics);

        // Act
        ActionResult<SummaryStatisticsDto> result = _controller.GetSummaryStatistics();

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
        SummaryStatistics returnValue = Assert.IsType<SummaryStatistics>(okResult.Value);
        Assert.Equal("2023-01", returnValue.MostExpensiveMonth);
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