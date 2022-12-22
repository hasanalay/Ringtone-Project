using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RingtoneController : Controller
    {
        public RingtoneController(object mockServiceObject)
        {
            throw new NotImplementedException();
        }

        public RingtoneController()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
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


        public IActionResult Create()
        {
            throw new NotImplementedException();
            //return View();
        }
    }
}