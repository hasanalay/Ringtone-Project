using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class CustomerController : Controller
    {
        private DbProjectContext db { get; }

        public CustomerController(DbProjectContext _context)
        {
            this.db = _context;
        }
        public IActionResult Favourite()
        {
            // Retrieve a list of all users from the database
            return View(db.Ringtones.Select(x=>x));
        }
        public IActionResult MyAccount()
        {
            return View();
        }

    }
}
