using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.ViewComponents.Dashboard
{
    public class ProjeList:ViewComponent
    {
        PortFolioManager portFolioManager = new PortFolioManager(new EfPortFolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portFolioManager.TGetList();
         


            return View(values);
        }
    }
}
