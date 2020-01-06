using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Lütfen E-mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage ="Lütfen E-mail tipine uygun bir mail adresi giriniz.")]
        public String Email { get; set; }


        [Required(ErrorMessage ="Şifre alanı boş geçilemez.")]
        [DataType(DataType.Password)]
        public String Sifre { get; set; }

    }
}