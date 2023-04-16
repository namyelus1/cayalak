using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class NewMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public NewMessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]


        public async Task<IActionResult> Index(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.SurName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("Index", "NewMessage"/*, new { area = "Writer" }*/);

        }
    }
}
