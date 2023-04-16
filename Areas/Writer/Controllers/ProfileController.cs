using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortoFolio.Areas.Writer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.SurName = values.SurName;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult>Index( UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagname = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagname;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imagname;
            }

            user.Name = p.Name;
            user.SurName = p.SurName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {

                return RedirectToAction("Index", "Login",new { area = "Writer" });
            }
            return View();
        }
    }
}
