using System.Linq;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RingtoneController : Controller
    {
        private DbProjectContext db = new DbProjectContext();
        public IActionResult Index()
        {
            //TODO: Implement Realistic Implementation
            return View(db.Ringtones.ToList());

        }

        public IActionResult Create()
        {
            //TODO: Implement Realistic Implementation
            return View();
        }

        public IActionResult Details()
        {
            //TODO: Implement Realistic Implementation
            return View();
        }

        public IActionResult List()
        {
            //TODO: Implement Realistic Implementation
            return View();
        }
    }
}