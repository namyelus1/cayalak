using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortoFolio.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Lütfen kullanıcıadınızı giriniz")]
        public string UserName { get; set; }



        [Required(ErrorMessage ="Lütfen resim url giriniz")]
        public  string Imageurl { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz")]
        public  string Password { get; set; }


        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz")]
        [Compare("Password",ErrorMessage = "Lütfen şifreler uyumlu değil ")]
        public  string ConfirimPassword { get; set; }



        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public  string Mail { get; set; }
      
    }
}
