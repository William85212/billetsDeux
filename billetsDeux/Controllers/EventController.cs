using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using billetsDeux.Services;
using Microsoft.AspNetCore.Mvc;

namespace billetsDeux.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllEvent()
        {
            return View(EventService.GetAllEvent().Result);
        }
        public IActionResult Get(int id)
        {
            return View(EventService.Get(id).Result);
        }
        public IActionResult GetDetailsEventById(int id)
        {
            return View(EventService.GetDetailsEventByid(id).Result);
        }
    }
}
