using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
          ;

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeletTestimonial(int id)
        {
            var values = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index", "testimonial");
        }
        [HttpGet]
      public IActionResult UpdateTestimonial(int id)
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            //ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hava sıcaklığı";
            //ViewBag.v3 = "Hakkımda  Düzenleme";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var values = testimonialManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
           

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index","Testimonial");

        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            ViewBag.v2 = "Hava sıcaklığı";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            ViewBag.v2 = "Hava sıcaklığı";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            testimonialManager.TAdd(p);
            return RedirectToAction("Index","Testimonial"); ;
        }
    }
}
