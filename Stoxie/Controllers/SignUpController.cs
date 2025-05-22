using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stoxie.Data;
using Stoxie.Models;
using Stoxie.Models.ViewModel;

namespace Stoxie.Controllers
{
    public class SignUpController : Controller
    {
        private readonly SignUpDbContext _context;
        private readonly ILogger<SignUpController> _logger;

        
        public SignUpController(SignUpDbContext context, ILogger<SignUpController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public IActionResult Register()
        {
            _logger.LogInformation("SignUpController > Register sayfası GET ile açıldı.");
            return View();
        }

        [HttpPost]
        public IActionResult Register(SignUp signUp)
        {
            if (!ModelState.IsValid) 
            {
                _logger.LogWarning("Sign Up formu geçersiz gönderildi.");
                return View(signUp);
            }

            try
            {
                _context.SignUps.Add(signUp);      // EF Core ile veri ekleme
                _context.SaveChanges();            // Veritabanına işlendi

                _logger.LogInformation("Yeni kullanıcı kaydı başarılı. Email: {Email}", signUp.Email);

                return RedirectToAction("RegisterIsSuccess", signUp);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Sign Up işlemi sırasında hata oluştu.");
                return View(signUp);
            }
        }

        public IActionResult RegisterIsSuccess(UserCreateVM userCreateVM)
        {
            _logger.LogInformation("Kullanıcı Success sayfasına yönlendirildi.");
            return View(userCreateVM);
        }
    }
}
