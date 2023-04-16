using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
        public PartialViewResult NavigationPartial()
        {
            ViewBag.v1 = "Yeteneklerim";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = "Yeteneklerim";
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
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
    }
}
