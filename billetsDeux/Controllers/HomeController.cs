using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using billetsDeux.Models;
using Microsoft.AspNetCore.Http;
using billetsDeux.Infrastructure;
using billetsDeux.Services;
using billetsDeux.Utils.HascMdp;

namespace billetsDeux.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionTools _sessionTools;
        private readonly IMdpHasc _hasc;

        public HomeController(ILogger<HomeController> logger, ISessionTools sessionTools, IMdpHasc mdpHasc) : base(sessionTools)
        {
            _logger = logger;
            _sessionTools = sessionTools;
            _hasc = mdpHasc;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("test", 42);
            //HttpContext.Session.SetString("testA","wiwi");
            //ViewBag.testA = HttpContext.Session.GetString("testA");
            _sessionTools.Test = "wuwu";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.test = _sessionTools.Test;
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public ActionResult InscriptionUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InscriptionUser(ClientWeb web)
        {
            ClientWeb clientExist = (from c in ClientService.Get().Result
                                     where c.Email.Equals(web.Email)
                                     select c).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (clientExist is null)
                {
                    string mdpH = _hasc.Hasc(web.Password);
                    web.Password = mdpH;
                    ClientService.Post(web);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.ErrorEmail = "L'adresse Email est déja utilisé";
                    return View(web);
                }
            }
            return View(web);
        }

        public ActionResult GetClient()
        {
            return View(ClientService.Get().Result);
        }
    }
}
