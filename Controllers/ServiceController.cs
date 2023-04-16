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
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServicesDal());

        public IActionResult Index()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = serviceManager.TGetList();
            return View(values);
        }
       [HttpGet]
        public IActionResult EditService()
        {
            
            var values = serviceManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Services p)
        {
           
            serviceManager.TUpdate(p);
            return View("EditService");
        }
        [HttpGet]
        public IActionResult AddService()
        {
           
           
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Services p)
        {
            
            serviceManager.TAdd(p);
            return View("EditService");
        }
        public IActionResult DeletService(int id)
        {
        
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
