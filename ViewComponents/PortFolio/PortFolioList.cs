using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_5_PROJE.ViewComponents.PoprtFolio
{
    public class PortFolioList:ViewComponent
    {
        PortFolioManager portFolioManager = new PortFolioManager(new EfPortFolioDal());
        public IViewComponentResult Invoke()
        {
            var values =portFolioManager.TGetList();
            return View(values);
        }
    }
}
