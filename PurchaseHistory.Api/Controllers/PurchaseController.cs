using Microsoft.AspNetCore.Mvc;
using PurchaseHistory.Api.DTOs;
using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Api.Controllers;

public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpGet("~/purchase/test")]
    [IgnoreAntiforgeryToken]
    [Produces("application/json")]
    public async Task<IActionResult> Test()
    {
        return Ok("Good!");
    }

    [HttpGet("~/purchase/GetAllPurchases")]
    [Produces("application/json")]
    public ActionResult<IEnumerable<PurchaseDto>> GetAllPurchases()
    {
        List<PurchaseDto> purchases = _purchaseService.GetPurchases().Select(p => new PurchaseDto
        {
            Id = p.Id,
            Name = p.Name,
            PurchasedAt = p.PurchasedAt,
            TotalCost = p.Quantity * p.UnitPrice
        }).ToList();

        return Ok(purchases);
    }

    [HttpGet("~/purchase/GetPurchaseById")]
    [Produces("application/json")]
    public ActionResult<IEnumerable<PurchaseDto>> GetPurchaseById(long id)
    {
        Purchase purchase = _purchaseService.GetPurchase(id);

        if (purchase == null)
        {
            return NotFound();
        }

        PurchaseDetailDto purchaseDetail = new()
        {
            Name = purchase.Name,
            PurchasedAt = purchase.PurchasedAt,
            Cost = purchase.Quantity * purchase.UnitPrice,
            Quantity = purchase.Quantity,
            UnitPrice = purchase.UnitPrice,
            Description = purchase.Description
        };

        return Ok(purchaseDetail);
    }

    [HttpGet("~/purchase/summary")]
    public ActionResult<SummaryStatisticsDto> GetSummaryStatistics()
    {
        SummaryStatistics statistics = _purchaseService.GetSummaryStatistics();
        return Ok(statistics);
    }
}