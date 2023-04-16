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
    public class Announcement2Controller : Controller
    {
        Announcement2Manager _announcement2Manager = new Announcement2Manager(new EfAnnouncement2Dal());
        public IActionResult Index()
        {

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString()); ;
            var values = _announcement2Manager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Announcement2Add()
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            return View();
        }
        [HttpPost]
        public IActionResult Announcement2Add(Announcement2 p)
        {


            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            _announcement2Manager.TAdd(p);
            //return View(expereince);
            return RedirectToAction("Index", "Announcement2");

        }
        public IActionResult DeletAnnouncement2(int id)
        {
            var values = _announcement2Manager.TGetByID(id);
            _announcement2Manager.TDelete(values);
            return RedirectToAction("Index", "Announcement2");
        }
        [HttpGet]
        public IActionResult Announcement2Update(int id)
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = _announcement2Manager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Announcement2Update(Announcement2 p)
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            _announcement2Manager.TUpdate(p);
            return RedirectToAction("Index", "Announcement2");
        }
    }
}
