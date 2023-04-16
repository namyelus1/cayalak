using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.ViewComponents
{
    public class Notification:ViewComponent
    {
        Announcement2Manager _announcemen2tManager = new Announcement2Manager(new EfAnnouncement2Dal());
        public IViewComponentResult Invoke()
        {
            var values = _announcemen2tManager.TGetList().Take(5).ToList();
          
            return View(values);
        }
    }
}

