using SmartEdu.Models.ORM.Context;
using SmartEdu.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartEdu.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext db = new SiteContext();
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            List<PostModel> postList = new List<PostModel>();
            List<ImageModel> ImageList = new List<ImageModel>();
            List<SayacModel> SayacList = new List<SayacModel>();
            List<ContactModel> IletisimList = new List<ContactModel>();

            var postEntities = db.Posts.ToList();
            var ımageentities = db.İmages.ToList();
            var ıletisimentities = db.İletisims.ToList();
            var sayacentities = db.Zamanlayıcıs.ToList();
         
            foreach (var post in postEntities)
            {
                PostModel postmodel = new PostModel();

                postmodel.Type = post.Type;
                postmodel.PostTitle = post.Baslik;
                postmodel.PostId = post.ID;
                postmodel.ImageId = post.ResimID;
                postmodel.PostContent = post.İcerik;
              
                postList.Add(postmodel);
            }
            foreach (var ımage in ımageentities)
            {
                ImageModel ımagemodel = new ImageModel();
                ımagemodel.ImageId = ımage.ID;
                ımagemodel.Type = ımage.Type;
                ımagemodel.Title = ımage.ResimBaslik;
                ımagemodel.Class = ımage.ImageClass;
                ımagemodel.ImagePath = ımage.ResimYolu;

                ImageList.Add(ımagemodel);
            }
            foreach (var contact in ıletisimentities)
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

            foreach (var counter in sayacentities)
            {
                SayacModel sayacmodel = new SayacModel();

                sayacmodel.CounterId = counter.ID;
                sayacmodel.CounterName = counter.sayacadı;
                sayacmodel.tarih = counter.tarih;

                SayacList.Add(sayacmodel);
            }
            vm.VmImage = ImageList;
            vm.VmIletisim = IletisimList;
            vm.VmSayacs = SayacList;
            vm.VmPosts = postList;

            return View(vm);
        }

        [Route("Hakkimizda")]
        public ActionResult About()
        {
            List<PostModel> postList = new List<PostModel>();
            List<ImageModel> ımgList = new List<ImageModel>();
            AboutModel mdl = new AboutModel();

            var postEntities = db.Posts.Where(x => x.Type == 3).ToList();
            var ImageEntities = db.İmages.ToList();
            var iletisimentity = db.İletisims.FirstOrDefault(x => x.ID == 1).Telefon;
            foreach (var post in postEntities)
            {
                PostModel postmodel = new PostModel();

                postmodel.Type = post.Type;
                postmodel.PostTitle = post.Baslik;
                postmodel.PostId = post.ID;
                postmodel.ImageId = post.ResimID;
                postmodel.PostContent = post.İcerik;

                postList.Add(postmodel);
            }
            foreach (var Images in ImageEntities)
            {
                ImageModel ımgModel = new ImageModel();

                ımgModel.ImageId = Images.ID;
                ımgModel.Title = Images.ResimBaslik;
                ımgModel.ImagePath = Images.ResimYolu;
                ımgModel.Type = Images.Type;
                ımgModel.Class = Images.ImageClass;

                ımgList.Add(ımgModel);
            }
            mdl.VmImage = ımgList;
            mdl.VmPosts = postList;
            mdl.Telefon = iletisimentity;
            return View(mdl);
        }

        [Route("İletisim")]
        public ActionResult Contact()
        {   
            IletisimModel mdl = new IletisimModel();
            List<ContactModel> IletisimList = new List<ContactModel>();
            List<ImageModel> ImgList = new List<ImageModel>();
            PostModel post = new PostModel();
            var ıletisimEntities = db.İletisims.Where(x => x.ID == 1).ToList();
            var ımageentities = db.İmages.ToList();
            var postentity = db.Posts.Where(x=>x.Type == 0);

            foreach (var item in postentity)
            {
                post.PostId = item.ID;
                post.PostTitle = item.Baslik;
                post.PostContent = item.İcerik;
            }

            foreach (var item in ıletisimEntities)
            {
                ContactModel ıletisim = new ContactModel();
                ıletisim.IletisimId = item.ID;
                ıletisim.Adres = item.Adres;
                ıletisim.Telefon = item.Telefon;
                ıletisim.Whatsapp = item.Whatsapp;
                ıletisim.Harita = item.Harita;

                IletisimList.Add(ıletisim);
            }

            foreach (var ımages in ımageentities)
            {
                ImageModel Imagemdl = new ImageModel();
                Imagemdl.Type = ımages.Type;
                Imagemdl.ImagePath = ımages.ResimYolu;
                Imagemdl.Title = ımages.ResimBaslik;

                ImgList.Add(Imagemdl);
            }
            mdl.VmIletisim = IletisimList;
            mdl.VmImage = ImgList;
            mdl.model = post;
            return View(mdl);
        }


    }
}

