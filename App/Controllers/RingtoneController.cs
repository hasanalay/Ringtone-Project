using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class RingtoneController : Controller
    {
        private DbProjectContext db { get; }
        public RingtoneController(DbProjectContext _context)
        {
            this.db = _context;
        }
        public IActionResult Index()
        {
            //TODO: Implement Realistic Implementation
            return View();

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
        [HttpPost]
        public IActionResult Search(string searchedWord)
        {
            //ViewData["Details"] = searchedWord;
            var searched = from x in db.Ringtones select x;
            searched = searched.Where(x => x.Name.Contains(searchedWord) || x.Details.Contains(searchedWord));
            return View(searched);
        }

    }
}