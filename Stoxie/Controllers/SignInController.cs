using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Stoxie.Data;
using Stoxie.Models;
using Stoxie.Models.ViewModel;
using System.Security.Claims;

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
        public async Task<IActionResult> Login(SignInViewModel model)
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

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
            };

            var identity = new ClaimsIdentity(claims, "StoxieCookie");

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("StoxieCookie", principal);  // kullanıcıyı sisteme login etmiş kabul ediyor.

            // Giriş başarılı → kullanıcıyı Welcome sayfasına yönlendir
            _logger.LogInformation("Kullanıcı başarılı şekilde giriş yaptı. Email: {Email}", model.Email);

            var userLoginVM = new UserLoginVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View("Welcome", userLoginVM);
            //return RedirectToAction("Welcome", "SignIn", user);   //RedirectToAction(actionName, controllerName, routeValues);
        }

        public IActionResult Welcome(UserLoginVM userLoginVM)
        {
            _logger.LogInformation("Kullanıcı Welcome sayfasına yönlendirildi.");
            return View(userLoginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("StoxieCookie");
            return RedirectToAction("Login", "SignIn");
        }

    }
}
