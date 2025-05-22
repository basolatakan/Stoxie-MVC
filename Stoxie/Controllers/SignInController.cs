using Microsoft.AspNetCore.Mvc;
using Stoxie.Data;
using Stoxie.Models;
using Stoxie.Models.ViewModel;

namespace Stoxie.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignUpDbContext _context;
        private readonly ILogger<SignInController> _logger;

        public SignInController(SignUpDbContext context, ILogger<SignInController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Giriş sayfasını göster
        public IActionResult Login()
        {
            _logger.LogInformation("Login sayfası açıldı.");
            return View();
        }

        // POST: Giriş formu gönderme
        [HttpPost]
        public IActionResult Login(SignInViewModel model)
        {
            _logger.LogWarning("Login denemesi yapıldı. Email: {Email}",model.Email);

            if (!ModelState.IsValid) 
            {
                _logger.LogWarning("Geçersiz login formu gönderildi.");
                return View(model);     // validasyon hatası varsa formu geri gösterecek
            }

            var user = _context.SignUps
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password); //İlk eşleşen kullanıcıyı bulur, yoksa null dönecek.

            if (user == null) 
            {
                _logger.LogWarning("Hatalı kullanıcı girişi. Email: {Email}", model.Email);
                ViewBag.Error = "E-posta veya şifre hatalı!";
                return View(model);
            }

            // Giriş başarılı → kullanıcıyı Welcome sayfasına yönlendir
            _logger.LogInformation("Kullanıcı başarılı şekilde giriş yaptı. Email: {Email}", model.Email);
            return RedirectToAction("Welcome", "SignIn", user);   //RedirectToAction(actionName, controllerName, routeValues);

        }

        public IActionResult Welcome(UserLoginVM userLoginVM)
        {
            _logger.LogInformation("Kullanıcı Welcome sayfasına yönlendirildi.");
            return View(userLoginVM);
        }
    }
}
