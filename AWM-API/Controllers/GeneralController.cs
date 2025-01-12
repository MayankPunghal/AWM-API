using Microsoft.AspNetCore.Mvc;
using usermanagement_api.Attributes;
using usermanagement_api.Utilities;

namespace usermanagement_api.Controllers
{
    public class GeneralController : Controller
    {
        [Route(ApiRoute.general.checkhealth)]
        [AllowAnonymousToken]
        [HttpGet]
        public async Task<IActionResult> healthcheck()
        {
            return Ok(new { Status = "ok" });
        }
    }
}
