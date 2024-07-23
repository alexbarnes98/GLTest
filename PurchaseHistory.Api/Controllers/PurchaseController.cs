using Microsoft.AspNetCore.Mvc;

namespace PurchaseHistory.Api.Controllers {
    public class PurchaseController : ControllerBase {
        [HttpGet("~/purchase/test")]
        [IgnoreAntiforgeryToken]
        [Produces("application/json")]
        public async Task<IActionResult> Test()
        {
            return Ok("Good!");
        }
    }
}
