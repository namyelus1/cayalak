using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.ds1 = c.PortFolios.Count();
            ViewBag.ds2 = c.Messages.Count();
            ViewBag.ds3 = c.Services.Count();
            return View();
        }
    }
}
