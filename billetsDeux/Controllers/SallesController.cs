using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using billetsDeux.Models;
using billetsDeux.Services;
using Microsoft.AspNetCore.Mvc;

namespace billetsDeux.Controllers
{
    public class SallesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public ActionResult Get()
        {

            IEnumerable<SalleWeb> ls = SallesService.Get().Result;

             return View(SallesService.Get().Result);
        }
        public ActionResult GetId(int id)
        {
            return View(SallesService.Get(id).Result);
        }
    }
}
