using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.Areas.Writer.Controllers
{
  
    [Area("Writer")]
    //[Route("Writer/[controller]/[action]")]
    public class MessageController : Controller
    {
        
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        //[Route("")]
        //[Route("Receiver")]
        public async Task< IActionResult> Receiver(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = _writerMessageManager.GetListReceiverMessage(p);

            return View(messagelist);
        }
        //[Route("")]
        //[Route("Sender")]
        public async Task<IActionResult> Sender(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = _writerMessageManager.GetListSenderMessage(p);

            return View(messagelist);
        }
        //[Route("MessageDetails/{id}")]

        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageManager.TGetByID(id);

            return View(writerMessage);
        }
        //[Route(" ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageManager.TGetByID(id);

            return View(writerMessage);
        }
        [HttpGet]
   
    
        public IActionResult SendMessage()
        {
            return View();

        }
        [HttpPost]
     
      
        public async Task <IActionResult> SendMessage(WriterMessage p)
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
            return RedirectToAction("Sender","Message",new { area = "Writer" });

        }
    }
}
