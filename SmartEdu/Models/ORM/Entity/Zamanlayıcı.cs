using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Models.ORM.Entity
{
    public class Zamanlayıcı
    {
        public int ID { get; set; }


        [Display(Name ="Sayaç Adı :")]
        [StringLength(150)]
        public String sayacadı { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Tarih :")]
        public DateTime tarih { get; set; }
        

    }
}