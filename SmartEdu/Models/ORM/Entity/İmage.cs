using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ORM.Entity
{
    public class İmage
    {
        public int ID { get; set; }

        [Display(Name = "Resim Başlığı :")]
        [StringLength(100)]
        public string ResimBaslik { get; set; }

        [Required]
        [Display(Name ="Resim Genişliği :")]
        public int Resimwidth { get; set; }

        [Required]
        [Display(Name = "Resim Yüksekliği :")]
        public int Resimheigth { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name ="Resim Yolu :")]
        public string ResimYolu { get; set; }

        public string ImageClass { get; set; }

        [NotMapped]
        [Display(Name ="Resim Yükle :")]
        public HttpPostedFileBase İmageFile { get; set; }

        public int Type { get; set; }

    }
}