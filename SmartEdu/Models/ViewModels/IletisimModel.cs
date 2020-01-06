using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEdu.Models.ViewModels
{
    public class IletisimModel

    {
        public IEnumerable<ImageModel> VmImage { get; set; }
        public IEnumerable<ContactModel> VmIletisim { get; set; }

        public PostModel model = new PostModel();
}
}