using billetsDeux.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Utils.CustomAttribute
{
    public class AccesAttribute : TypeFilterAttribute
    {
        public AccesAttribute() : base(typeof(AuthRequiredFilter))
        {

        }

        public class AuthRequiredFilter : IAuthorizationFilter
        {
            public void  OnAuthorization(AuthorizationFilterContext context)
            {
                ISessionTools sessionTools = (ISessionTools)context.HttpContext.RequestServices.GetService(typeof(ISessionTools));

                if (sessionTools.clientWeb is null)
                {
                    context.Result = new RedirectToRouteResult(new { action = "", controller = "" });
                }
            }
        }
    }
}
