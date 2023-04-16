using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
    public class ExpereinceController : Controller
    {
        ExpereinceManager expereinceManager = new ExpereinceManager(new EfExpereinceDal());
        public IActionResult Index()
        {

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = expereinceManager.TGetList();
            return View(values);
        }
    
        public IActionResult DeletExpereince(int id)
        {
            var values = expereinceManager.TGetByID(id);
            expereinceManager.TDelete(values);
            return RedirectToAction("Index", "Expereince");
        }
        [HttpGet]
        public IActionResult ExpereinceAdd()
        {
        
            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            return View();
        }
        [HttpPost]
        public IActionResult ExpereinceAdd(Expereince expereince)
        {

         
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            expereinceManager.TAdd(expereince);
            //return View(expereince);
            return RedirectToAction("Index", "Expereince");

        }
        [HttpGet]
        public IActionResult ExpereinceUpdate(int id)
        {
           
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = expereinceManager.TGetByID(id);
            return View (values);
        }
        [HttpPost]
        public IActionResult ExpereinceUpdate(Expereince p)
        {
        
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            expereinceManager.TUpdate(p);
            return RedirectToAction("Index","Expereince");
        }

    }
}
