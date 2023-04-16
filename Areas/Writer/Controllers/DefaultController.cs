using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortoFolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]

    public class DefaultController : Controller
    {
        Announcement2Manager _announcemen2tManager = new Announcement2Manager(new EfAnnouncement2Dal());
        public IActionResult Index()
        {
            var values = _announcemen2tManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement2 announcement2 = _announcemen2tManager.TGetByID(id);

            return View(announcement2);
        }
    }
}
