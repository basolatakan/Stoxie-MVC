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

        public SignUpController(SignUpDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(SignUp signUp)
        {
            if (!ModelState.IsValid) 
            {
                return View(signUp);
            }

            _context.SignUps.Add(signUp);      // EF Core ile veri ekleme
            _context.SaveChanges();            // Veritabanına işle


            return RedirectToAction("RegisterIsSuccess", signUp);
        }


        public IActionResult RegisterIsSuccess(UserCreateVM userCreateVM)
        {
            return View(userCreateVM);
        }
    }
}
