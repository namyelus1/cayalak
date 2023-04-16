using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_5_PROJE.ViewComponents.Expereince
{
    public class ExpereniceList:ViewComponent
    {
        ExpereinceManager expereinceManager = new ExpereinceManager(new EfExpereinceDal());
        public IViewComponentResult Invoke()
        {
            var values = expereinceManager.TGetList();
            return View(values);
        }
    }
}
