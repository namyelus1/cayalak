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
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;
            ViewBag.v2 = "Hava Durumu";
            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = socialMediaManager.TGetList();
            return View(values);
        }
        public IActionResult DeletSocialMedia(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index","SocialMedia");
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;
            ViewBag.v2 = "Hava Durumu";
            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;
            ViewBag.v2 = "Hava Durumu";
            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index", "SocialMedia");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;
            ViewBag.v2 = "Hava Durumu";
            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = socialMediaManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia p)
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;
            ViewBag.v2 = "Hava Durumu";
            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            socialMediaManager.TUpdate(p);
            return RedirectToAction("Index", "SocialMedia");
        }
    }
}
