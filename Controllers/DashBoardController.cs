using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortoFolio.Controllers
{


    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = (DateTime.Now.ToLongDateString());
            //ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hava sıcaklığı.......";
            //ViewBag.v3 = "Hakkımda  Düzenleme";

            string api = "07c339e030efa892665e73c64803ebbd";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Aydın&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = System.Xml.Linq.XDocument.Load(connection);
            ViewBag.v3 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View() ;
        }
    }
}
