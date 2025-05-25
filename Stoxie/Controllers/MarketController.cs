using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Stoxie.Controllers
{
    public class MarketController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
