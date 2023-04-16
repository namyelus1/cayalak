using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_5_PROJE.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {





        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}