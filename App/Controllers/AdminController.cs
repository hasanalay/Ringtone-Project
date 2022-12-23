
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
                User user = db.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                }
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }

        //USER OPERATIONS

        public IActionResult ViewUsers()
        {
            // Retrieve a list of all users from the database
            return View(db.Users.Select(users => users));
        }
        public IActionResult DeleteUser(int id)
        {
            var result = db.Users.Find(id);
            db.Users.Remove(result);
            db.SaveChanges();
            return RedirectToAction(nameof(ViewUsers));
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User x)
        {
            var result = db.Users.Add(x);
            db.SaveChanges();
            return RedirectToAction(nameof(ViewUsers));
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var result = db.Users.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateUser(User x)
        {
            var result = db.Users.Find(x.Id);
            result.Name = x.Name;
            result.Role = x.Role;
            result.Email = x.Email;
            db.SaveChanges();
            return RedirectToAction(nameof(ViewUsers));
        }



        //RINGTONE OPERATIONS
        public IActionResult ViewRingtones()
        {
            // Retrieve a list of all users from the database
            return View(db.Ringtones.Select(x => x));
        }
        public IActionResult DeleteRingtone(int id)
        {
            var result = db.Ringtones.Find(id);
            db.Ringtones.Remove(result);
            db.SaveChanges();
            return RedirectToAction(nameof(ViewRingtones));
        }
        [HttpGet]
        public IActionResult AddRingtone()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRingtone(Ringtone x)
        {
            var result = db.Ringtones.Add(x);
            db.SaveChanges();
            return RedirectToAction(nameof(ViewRingtones));
        }

        [HttpGet]
        public IActionResult UpdateRingtone(int id)
        {
            var result = db.Ringtones.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateRingtone(Ringtone x)
        {
            var result = db.Ringtones.Find(x.Id);
            result.Name = x.Name;
            result.Price = x.Price;
            result.Details = x.Details;
            result.Imageurl = x.Imageurl;
            result.Audiourl = x.Audiourl;
            db.SaveChanges();
            return RedirectToAction(nameof(ViewRingtones));
        }

    }
}