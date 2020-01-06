using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class AboutModel
    {
        public IEnumerable<PostModel> VmPosts { get; set; }
        public IEnumerable<ImageModel> VmImage { get; set; }
        public string Telefon { get; set; }
    }
}