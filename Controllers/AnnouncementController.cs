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
    public class AnnouncementController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString()); ;
            var values = _announcementManager.TGetList();
            return View(values);
        }
        public IActionResult DeletAnnouncement(int id)
        {
            var values = _announcementManager.TGetByID(id);
         _announcementManager.TDelete(values);
            return RedirectToAction("Index", "Announcement");
        }
        [HttpGet]
        public IActionResult AnnouncementAdd()
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            return View();
        }
        [HttpPost]
        public IActionResult AnnouncementAdd(Announcement p)
        {


            ViewBag.v3 = (DateTime.Now.ToLongDateString());
          _announcementManager.TAdd(p);
            //return View(expereince);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult AnnouncemenUpdate(int id)
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = _announcementManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult AnnouncemenUpdate(Announcement p)
        {

            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            _announcementManager.TUpdate(p);
            return RedirectToAction("Index", "Announcement");
        }
    }
}
