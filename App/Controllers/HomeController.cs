using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Ringtones);
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