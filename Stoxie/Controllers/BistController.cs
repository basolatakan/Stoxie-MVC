using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Stoxie.Controllers
{
    public class BistController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
