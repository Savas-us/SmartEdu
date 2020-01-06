using SmartEdu.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PostModel> VmPosts { get; set; }
        public IEnumerable<ImageModel> VmImage { get; set; }
        public IEnumerable<ContactModel> VmIletisim { get; set; }
        public IEnumerable<SayacModel> VmSayacs { get; set; }
    }
}