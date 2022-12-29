using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Linq;
using System.Net;
using System;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;

namespace App.Controllers
{

    public class HomeController : Controller
    {
        private DbProjectContext db { get; }
        public HomeController(DbProjectContext _context)
        {
            this.db = _context;
        }

        public IActionResult Index(string searchString)
        {

            if (db.Ringtones == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var ringtones = from r in db.Ringtones select r;


            if (!String.IsNullOrEmpty(searchString))
            {
                ringtones = ringtones.Where(s => s.Name!.Contains(searchString) || s.Details.Contains(searchString));

            }


            return View(ringtones);
        }
        public IActionResult Details(int id)
        {

            return View(db.Ringtones.Where(p => p.Id == id).FirstOrDefault());
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Category(int id)
        {
            var result = db.Ringtones.Where(x => x.CategoryId == id).ToList();
            return View(result);
        }


        public IActionResult AddtoCart(int id)
        {
            Ringtone r = db.Ringtones.Where(x => x.Id == id).FirstOrDefault();
            return View(r);
        }

        List<CardPayment> li = new List<CardPayment>();

        [HttpPost]
        public IActionResult AddtoCart(Ringtone r, int id)
        {
            Ringtone ring = db.Ringtones.Where(x => x.Id == id).SingleOrDefault();
            CardPayment c = new CardPayment();
            c.RingtoneId = ring.Id;
            c.Amount = ring.Price;
            if (TempData["CardPayment"] == null)
            {
                li.Add(c);
            }
            else
            {
                List<CardPayment> li2 = TempData["CardPayment"] as List<CardPayment>;
                li2.Add(c);
                TempData["CardPayment"] = li2;
            }

            TempData.Keep();

            return RedirectToAction("Index");

        }
        public ActionResult checkout()
        {
            TempData.Keep();


            return View();
        }
    }
}
