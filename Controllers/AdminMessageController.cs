using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());


            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v3 = (DateTime.Now.ToLongDateString());

            var values = writerMessageManager.TGetByID(id);

            return View(values);
        }
        public IActionResult DeletAdminMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
           writerMessageManager.TDelete(values);
            return RedirectToAction("ReceiverMessageList");
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {

      
            return View();
        }
        [HttpPost]
        public IActionResult AdminSendMessage(WriterMessage p)
        {

            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            p.ReceiverName = usernamesurname;

            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
