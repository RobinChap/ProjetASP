using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventions_by_Women.Data;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Inventions_by_Women.Backoffice
{
    public abstract class BOControllerBase : Controller
    {
        private InventionsDbContext _context;

        public BOControllerBase(InventionsDbContext _context)
        {
            this._context = context;
        }

    }
}
