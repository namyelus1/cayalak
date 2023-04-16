using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_5_PROJE.ViewComponents.Skill
{
    public class ServiceList:ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EfServicesDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
    }
}
