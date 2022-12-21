using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Linq;
using System.Net;

namespace App.Controllers
{

    public class HomeController : Controller
    {
        private DbProjectContext db { get; }
        public HomeController(DbProjectContext _context)
        {
            this.db = _context;
        }

        public IActionResult Index()
        {

            return View(this.db.Ringtones.ToList());

        }

        public IActionResult Details(int id)
        {

            return View(db.Ringtones.Where(p => p.Id == id).FirstOrDefault());
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}