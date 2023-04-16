using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.ViewComponents.Dashboard
{
    public class AdminNotifacationNavbarList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
