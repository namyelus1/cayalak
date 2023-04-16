using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{
    public class ExprienceajaxController : Controller
    {
        ExpereinceManager experinceManager = new ExpereinceManager(new EfExpereinceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            //ViewBag.v1 = "Düzenleme";
            //ViewBag.v2 = "Hava sıcaklığı";
            //ViewBag.v3 = "Hakkımda  Düzenleme";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;





            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experinceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Expereince p)
        {
            experinceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExprerienceID)
        {
            var v = experinceManager.TGetByID(ExprerienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = experinceManager.TGetByID(id);
            experinceManager.TDelete(v);
            return NoContent();
        }
        public IActionResult UpdateExperince(Expereince p)
        {
            var v = experinceManager.TGetByID(p.ExpereinceID);
            experinceManager.TUpdate(v);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
