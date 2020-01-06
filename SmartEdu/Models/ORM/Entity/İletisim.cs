using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ORM.Entity
{
    public class İletisim
    {

        public int ID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [Required]
        public string Adres { get; set; }
        [DataType(DataType.Url)]
        public string İnstagram { get; set; }
        [DataType(DataType.Url)]
        public string Twitter { get; set; }
        [DataType(DataType.Url)]
        public string Facebook { get; set; }
        [DataType(DataType.Url)]
        public string Youtube { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Whatsapp { get; set; }
        [DataType(DataType.Url)]
        public string Harita { get; set; }
    }
}