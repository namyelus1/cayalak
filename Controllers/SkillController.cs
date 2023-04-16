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
    [Authorize(Roles ="Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
          
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill p)
        {
        
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            skillManager.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeletSkill(int id)
        {
            
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return View();
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
          
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values_ = skillManager.TGetByID(id);

            return View(values_);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
           
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            skillManager.TUpdate(skill);
            return RedirectToAction("Index", "Skill");
        }
    }
}
