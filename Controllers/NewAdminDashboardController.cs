using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewAdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Yeteneklerim";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
        public IActionResult Dashboard()
        {
         
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult NavigationPartial()
        {
            ViewBag.v1 = "Yeteneklerim";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}
