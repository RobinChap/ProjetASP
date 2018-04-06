using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventions_by_Women.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((Controller)context.Controller).TempData["REDIRECT_BO"] =
                context.HttpContext.Request.Path.Value;
            //base.OnActionExecuting(context);
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("USER_BO")))
            {
                context.Result = new RedirectToActionResult("Login", "Authentication", new { area = "Backoffice" });
            }
        }
    }


}
