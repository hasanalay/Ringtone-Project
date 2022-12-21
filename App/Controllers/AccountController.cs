using Microsoft.AspNetCore.Mvc;
using App.Models;
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
        public ActionResult Admin()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the provided username and password match a user in the database
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        public ActionResult ViewUsers()
        {
            // Retrieve a list of all users from the database
            return View(db.Users.Select(users => users));
        }

        // Action to add a new user
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            // Validate the user input
            if (ModelState.IsValid)
            {
                // Save the new user to the database
                //SaveUserToDatabase(user);

                // Redirect to the user list view
                return RedirectToAction("ViewUsers");
            }

            // If the input is invalid, return the user to the add user form
            return View("AddUser");
        }

        // Other actions for managing users, ringtones, and categories
    }
}

