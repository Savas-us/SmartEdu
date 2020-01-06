using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ORM.Entity
{
    public class Post
    {

        [Display(Name ="İçerik ID :")]
        public int ID { get; set; }
        [Display(Name ="Başlık :")]
        public string Baslik { get; set; }
        [Display(Name ="İçerik :")]
        public string İcerik { get; set; }
        [Display(Name ="Resim No :")]
        public int? ResimID { get; set; }
        public int Type { get; set; }

        [ForeignKey("ResimID")]
        public virtual İmage Image { get; set; }

    }
}