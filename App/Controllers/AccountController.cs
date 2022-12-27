using App.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace App.Controllers
{

    public class AccountController : Controller
    {
        private DbProjectContext db { get; }

        public AccountController(DbProjectContext _context)
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
                User user = db.Users.SingleOrDefault(x => x.Name.ToLower() == model.Name.ToLower() && x.Password == model.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(" ", model.Name.ToString()));
                    claims.Add(new Claim("id", model.Id.ToString()));


                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Name or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }


        public IActionResult MyAccount(User model)

        {
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Email == model.Email))
                {
                    ModelState.AddModelError(nameof(model.Email), "This email is already exist!");
                    return View(model);
                }
                User user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else { return View(model); }
        }
        [HttpPost]
        public IActionResult UpdateProfile(User a)
        {
            var result = db.Users.Find(a.Id);
            result.Name = a.Name;
            result.Password = a.Password;
            db.SaveChanges();
            return RedirectToAction(nameof(Logout));
        }

        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var result = db.Users.Find(id);
            return View(result);
        }

    }
}
