using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Stoxie.Controllers
{
    public class FavoriteController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
