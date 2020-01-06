using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class ImageModel
    {
        public int Type { get; set; }
       
        public string ImagePath { get; set; }

        public int ImageId { get; set; }
        public string Title { get; set; }

        public string Class { get; set; }
    }
}