using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventions_by_Women.Models;
using Inventions_by_Women.Data;

namespace Inventions_by_Women.Controllers
{
    public class UsersController : Controller
    {
        private readonly InventionsDbContext context;

        public UsersController(InventionsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = user.Password.Encrypt();
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                TempData["Message"] = "Utilisateur engristré";

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
