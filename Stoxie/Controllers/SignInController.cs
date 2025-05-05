using Microsoft.AspNetCore.Mvc;
using Stoxie.Data;
using Stoxie.Models;
using Stoxie.Models.ViewModel;

namespace Stoxie.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignUpDbContext _context;

        public SignInController(SignUpDbContext context)
        {
            _context = context;
        }

        // GET: Giriş sayfasını göster
        public IActionResult Login()
        {
            return View();
        }

        // POST: Giriş formu gönderme
        [HttpPost]
        public IActionResult Login(SignInViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);     // validasyon hatası varsa formu geri gösterecek
            }

            var user = _context.SignUps
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password); //İlk eşleşen kullanıcıyı bulur, yoksa null döner

            if (user == null) 
            {
                ViewBag.Error = "E-posta veya şifre hatalı!";
                return View(model);
            }

            // Giriş başarılı → kullanıcıyı Welcome sayfasına yönlendir
            return RedirectToAction("Welcome", "SignIn", user);   //RedirectToAction(actionName, controllerName, routeValues);

        }

        public IActionResult Welcome(UserLoginVM userLoginVM)
        {
            return View(userLoginVM);
        }
    }
}
