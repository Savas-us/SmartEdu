using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class PostModel
    {
        public int Type { get; set; }
        public int PostId  {get; set; }
        public string PostTitle { get; set; }
        public string  PostContent { get; set; }
        public int? ImageId { get; set; }
    }
}