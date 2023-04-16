using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    //[Route("Portfolio/PortList")]
    public class PortFolioController : Controller
    {
        PortFolioManager portoFolioManager = new PortFolioManager(new EfPortFolioDal());

        public IActionResult PortList()
        {
            ViewBag.v1 = "Projelerim";
            ViewBag.v2 = "ProjeListesi";
            ViewBag.v3 = (DateTime.Now.ToLongDateString());
            var values = portoFolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        //[Route("")]
        //[Route("AddPortoFolio")]
        public IActionResult AddPortoFolio(int id)
        {
            var values = portoFolioManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        //[Route("")]
        //[Route("AddPortoFolio")]
        public IActionResult AddPortoFolio(PortFolio portoFolio)
        {
            portoFolioManager.TAdd(portoFolio);
            return View();

        }
    }
}
