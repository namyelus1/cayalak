using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.s1 = c.Skills.Count();
            ViewBag.s2 = c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.s3 = c.Messages.Where(x=>x.Status==true).Count();
            ViewBag.s4 = c.Expereinces.Count();
        
           
            return View();
        }
    }
}
