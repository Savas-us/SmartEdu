using SmartEdu.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SmartEdu.Models;
using SmartEdu.Models.ORM.Entity;
using System.IO;

namespace SmartEdu.Controllers
{
    [Authorize]
    public class AdminPanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private SiteContext db = new SiteContext();

        public ActionResult Yazılar()
        {
            var model = db.Posts.ToList();

            return View(model);

        }

        [HttpGet]
        public ActionResult YazıDüzenle(int id)
        {
            Post gelenpost = db.Posts.Find(id);

            if (gelenpost == null)
                return HttpNotFound();

            return View("Güncelle", gelenpost);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YazıDüzenle(Post model)
        {
            
            if (model != null)
            {
                Post güncellenecekpost = db.Posts.Find(model.ID);
                İmage resim = db.İmages.Find(model.ResimID);
                if (güncellenecekpost != null && resim == null)
                {
                    güncellenecekpost.Baslik = model.Baslik;
                    güncellenecekpost.İcerik = model.İcerik;

                    db.SaveChanges();

                    return RedirectToAction("Yazılar", "AdminPanel");
                }
                else if (güncellenecekpost != null && resim != null)
                {
                    güncellenecekpost.Baslik = model.Baslik;
                    güncellenecekpost.İcerik = model.İcerik;
                    resim.ResimBaslik = model.Baslik;
                    db.SaveChanges();

                    return RedirectToAction("Yazılar", "AdminPanel");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }  
        }



        public ActionResult Resimler()
        {
            var resim = db.İmages.ToList();
            return View(resim);
        }

        [HttpGet]
        public ActionResult ResimDüzenle(int id)
        {
            İmage gelenresim = db.İmages.Find(id);

            if (gelenresim == null)
                return HttpNotFound();

            return View("ResimGüncelle", gelenresim);
        }


        [HttpPost]
        public ActionResult ResimDüzenle(İmage resim)
        {
                String dosyaadı = Path.GetFileNameWithoutExtension(resim.İmageFile.FileName);
                String uzantı = Path.GetExtension(resim.İmageFile.FileName);
                 dosyaadı = DateTime.Now.ToString("dd/MM/yyyy") + dosyaadı + uzantı;
                resim.ResimYolu = "\\Content\\Site\\images\\" + dosyaadı;
                dosyaadı = Path.Combine( Server.MapPath("\\Content\\Site\\images\\"),dosyaadı);


                resim.İmageFile.SaveAs(dosyaadı);

                if (db != null)
                {
                İmage güncelle = db.İmages.Find(resim.ID);

                if (güncelle != null)
                {
                    güncelle.ResimBaslik = resim.ResimBaslik;
                    güncelle.ResimYolu = resim.ResimYolu;
                    db.SaveChanges();
                }
                else
                    return HttpNotFound(); 
                }
                else
                {
                    return HttpNotFound();
                }
            

            ModelState.Clear();

            return RedirectToAction("Resimler", "AdminPanel");
        }

        public ActionResult İletisim()
        {
            var iletisim = db.İletisims.ToList();

            return View(iletisim);
        }

        [HttpGet]
        public ActionResult İletisimGüncelle(int id)
        {
            İletisim bilgi = db.İletisims.Find(id);

            if (bilgi == null)
                return HttpNotFound();

            return View("Güncelİletisim",bilgi);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult İletisimGüncelle(İletisim gelen)
        {

            if (gelen != null)
            {
                İletisim güncellenen = db.İletisims.Find(gelen.ID);

                if (güncellenen == null)
                {
                    return HttpNotFound();
                }
                güncellenen.Telefon = gelen.Telefon;
                güncellenen.İnstagram = gelen.İnstagram;
                güncellenen.Twitter = gelen.Twitter;
                güncellenen.Facebook = gelen.Facebook;
                güncellenen.Youtube = gelen.Youtube;
                güncellenen.Harita = gelen.Harita;
                güncellenen.Adres= gelen.Adres;
                güncellenen.Whatsapp = gelen.Whatsapp;

                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }    
            ModelState.Clear();
            return RedirectToAction("İletisim","AdminPanel");
        }


        public ActionResult Tarih()
        {
            var liste = db.Zamanlayıcıs.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult TarihGüncelle(int id)
        {
            Zamanlayıcı zaman = db.Zamanlayıcıs.Find(id);

            if (zaman == null)
                  return HttpNotFound();
            
            return View("GüncelTarih",zaman);
        }

        [HttpPost]
        public ActionResult TarihGüncelle(Zamanlayıcı zaman)
        {
            if (zaman != null)
            {
                Zamanlayıcı güncellenen = db.Zamanlayıcıs.Find(zaman.ID);
                if (güncellenen == null)
                {
                    return HttpNotFound();
                }
                güncellenen.sayacadı = zaman.sayacadı;
                güncellenen.tarih = zaman.tarih;
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            ModelState.Clear();
            return RedirectToAction("Tarih", "AdminPanel");
        }

    }
}