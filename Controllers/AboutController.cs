using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            //ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hava sıcaklığı";
            //ViewBag.v3 = "Hakkımda  Düzenleme";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var values = aboutManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            
            aboutManager.TUpdate(about);
            return View("EditAbout");
        }
    }
}
