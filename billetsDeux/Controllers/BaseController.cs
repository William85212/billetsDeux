using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using billetsDeux.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace billetsDeux.Controllers
{
    public class BaseController : Controller
    {
        protected internal ISessionTools SessionTools { get; set; }
        public BaseController(ISessionTools sess)
        {
            SessionTools = sess;
        }
    }
}
