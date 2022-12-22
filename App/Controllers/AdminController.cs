
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class AdminController : Controller
    {
        private DbProjectContext db { get; }

        public AdminController(DbProjectContext _context)
        {
            this.db = _context;
        }

        public IActionResult Login()
        {
            //video 1 saat 48. dk
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Role == model.Role))
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);

            }
            else { return View(model); }

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewUsers()
        {
            // Retrieve a list of all users from the database
            return View(db.Users.Select(users => users));
        }
    }
}