using SmartEdu.Models.ORM.Context;
using SmartEdu.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartEdu.Controllers
{
    public class _LayoutController : Controller
    {
        private SiteContext db = new SiteContext();


        
        public ActionResult CallHeader()
        {
            LayoutModel mdl = new LayoutModel();
            List<ImageModel> ImageList = new List<ImageModel>();
            List<ContactModel> IletisimList = new List<ContactModel>();

            var ımageentities = db.İmages.Where(x => x.Type == 0).ToList();
            var contactentities = db.İletisims.Where(x => x.ID == 1).ToList();

            foreach (var item in ımageentities)
            {
                ImageModel ımgmodel = new ImageModel();
                ımgmodel.Type = item.Type;
                ımgmodel.Title = item.ResimBaslik;
                ımgmodel.Class = item.ImageClass;
                ımgmodel.ImagePath = item.ResimYolu;

                ImageList.Add(ımgmodel);
            }

            foreach (var contact in contactentities)
            {
                ContactModel ıletisimmodel = new ContactModel();

                ıletisimmodel.IletisimId = contact.ID;
                ıletisimmodel.Whatsapp = contact.Whatsapp;

                IletisimList.Add(ıletisimmodel);
            }

            mdl.VmIletisim = IletisimList;
            mdl.VmImage = ImageList;
            return PartialView("~/Views/Shared/_Header.cshtml", mdl);
        }

        
        public ActionResult CallFooter()
        {
            LayoutModel mdl = new LayoutModel();
            List<ContactModel> IletisimList = new List<ContactModel>();

            var contactentities = db.İletisims.Where(x => x.ID == 1).ToList();

            foreach (var contact in contactentities)
            {
                ContactModel ıletisimmodel = new ContactModel();

                ıletisimmodel.IletisimId = contact.ID;
                ıletisimmodel.Telefon = contact.Telefon;
                ıletisimmodel.Adres = contact.Adres;
                ıletisimmodel.Instagram = contact.İnstagram;
                ıletisimmodel.Twitter = contact.Twitter;
                ıletisimmodel.Facebook = contact.Facebook;
                ıletisimmodel.Youtube = contact.Youtube;
                ıletisimmodel.Whatsapp = contact.Whatsapp;

                IletisimList.Add(ıletisimmodel);
            }
            mdl.VmIletisim = IletisimList;

            return PartialView("~/Views/Shared/_Footer.cshtml", mdl);
        }
    }
}