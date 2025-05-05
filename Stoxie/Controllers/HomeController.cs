using Microsoft.AspNetCore.Mvc;
using Stoxie.Data;
using Stoxie.Models;
using Stoxie.Models.ViewModel;
using System.Diagnostics;

namespace Stoxie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignUpDbContext _context;

        public HomeController(ILogger<HomeController> logger, SignUpDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactFormVM model)
        {
            if (!ModelState.IsValid)
            {
                // Formda hata varsa tekrar göster
                return View(model);
            }

            // ViewModel → Entity'e çeviriyoruz
            var contactMessage = new ContactMessage
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                CreateAt = DateTime.Now
            };

            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();

            // Kullanıcıya mesajı başarıyla gönderildiğini bildir
            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction("Contact");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
