﻿using billetsDeux.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Utils.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class IsLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            BaseController controller = (BaseController)context.Controller;
            controller.ViewBag.Islogged = !(controller.SessionTools.clientWeb is null);
        }
    }
}
