using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class LayoutModel
    {
        public IEnumerable<ImageModel> VmImage { get; set; }
        public IEnumerable<ContactModel> VmIletisim { get; set; }

    }
}