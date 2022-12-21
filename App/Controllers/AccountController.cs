using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        private DbProjectContext db { get; }

        public AccountController(DbProjectContext _context)
        {
            this.db = _context;
        }

        public IActionResult Login()
        {
            //video 1 saat 48. dk
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(db.Users.Any(x=> x.Email == model.Email))
                {
                    ModelState.AddModelError(nameof(model.Email), "This email is already exist!");
                    return View(model);
                }
                User user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else { return View(model); }
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
