using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventions_by_Women.Data;
using Microsoft.AspNetCore.Mvc;
using Inventions_by_Women.Backoffice.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Inventions_by_Women.Filters;

namespace Inventions_by_Women.Backoffice.Controllers
{
    public class AuthenticationController : BOControllerBase
    {
        public AuthenticationController(InventionsDbContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthencationLoginViewModel model)
        {
            //ModelState.Remove("Password");
            if (!(model?.Login == "admin" && model?.Password == "admin"))
                ModelState.AddModelError("Login", "Login ou mot de passe incorrect.");

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("USER_BO", JsonConvert.SerializeObject(model));

                var url = TempData["REDIRECT_BO"]?.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                    return Redirect(url);
                //return RedirectToAction("Index", "Dashboard", new { area ="" });
                return RedirectToAction("Index", "Dashboard");
            }
            else
                return View();
        }

        [HttpGet]
        [Filters.AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_BO");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
