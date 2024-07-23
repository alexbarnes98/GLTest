using Microsoft.AspNetCore.Mvc;
using PurchaseHistory.Api.DTOs;
using PurchaseHistory.Core.Entities;
using PurchaseHistory.Core.Interfaces;

namespace PurchaseHistory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ILogger<PurchaseController> _logger;

        public PurchaseController(IPurchaseService purchaseService, ILogger<PurchaseController> logger)
        {
            _purchaseService = purchaseService;
            _logger = logger;
        }

        [HttpGet("test")]
        [IgnoreAntiforgeryToken]
        [Produces("application/json")]
        public async Task<IActionResult> Test()
        {
            return Ok("Good!");
        }

        [HttpGet("GetAllPurchases")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<PurchaseDto>> GetAllPurchases()
        {
            try
            {
                _logger.LogInformation("Getting all purchases");
                List<PurchaseDto> purchases = _purchaseService.GetPurchases().Select(p => new PurchaseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasedAt = p.PurchasedAt,
                    TotalCost = p.Quantity * p.UnitPrice
                }).ToList();

                return Ok(purchases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all purchases");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetPurchaseById")]
        [Produces("application/json")]
        public ActionResult<PurchaseDetailDto> GetPurchaseById(long id)
        {
            try
            {
                _logger.LogInformation("Getting purchase by id: {Id}", id);
                Purchase purchase = _purchaseService.GetPurchase(id);

                if (purchase == null)
                {
                    _logger.LogWarning("Purchase with id: {Id} not found", id);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting purchase by id: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("summary")]
        [Produces("application/json")]
        public ActionResult<SummaryStatisticsDto> GetSummaryStatistics()
        {
            try
            {
                _logger.LogInformation("Getting summary statistics");
                SummaryStatistics statistics = _purchaseService.GetSummaryStatistics();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting summary statistics");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
