using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ORM.Entity
{
    public class AdminUser
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public String Email { get; set; }

        [Required]
        public String Sifre { get; set; }

        [StringLength(20)]
        public String Adı { get; set; }

        [StringLength(20)]
        public String Soyadı { get; set; }


    }
}