using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventions_by_Women.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventions_by_Women.Backoffice
{
    public class DashboardController : BOControllerBase
    {

        public DashboardController(InventionsDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
