using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    public class PortFolioController : Controller
    {
        PortFolioManager portFolioManager = new PortFolioManager(new EfPortFolioDal());
        public IActionResult Index()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            var values=    portFolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortFolio()
        {
        
          
            return View();
        }

        [HttpPost]
        public IActionResult AddPortFolio(PortFolio p)
        {
        
            PortFolioValidator validations = new PortFolioValidator();
            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                portFolioManager.TAdd(p);
                return View("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
               }
        
          
        }
        [HttpGet]
        public IActionResult EditPortFolio(int id)
        {
         
            var values = portFolioManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortFolio(PortFolio p)
        {
           
            PortFolioValidator validations = new PortFolioValidator();
            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                portFolioManager.TUpdate(p);
                return View(p);
            }

        
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



              }

        
        public IActionResult DeletPortFolio(int id)
        {
            var values = portFolioManager.TGetByID(id);
            portFolioManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
