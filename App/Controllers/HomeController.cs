using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Linq;
using System;
namespace App.Controllers
{

    public class HomeController : Controller
    {
        private DbProjectContext db = new DbProjectContext();

        public IActionResult Index()
        {

            return View(db.Ringtones.ToList());

        }

        public IActionResult Details(int id)
        {
            return View(); //Repository.GetById(id)
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}