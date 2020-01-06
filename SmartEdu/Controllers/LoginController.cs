using SmartEdu.Models.Login;
using SmartEdu.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmartEdu.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        private SiteContext db = new SiteContext();

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.Email == model.Email && x.Sifre == model.Sifre))
                {

                            FormsAuthentication.SetAuthCookie(model.Email,false);

                                return RedirectToAction("Index", "AdminPanel");
                }
                else
                {
                    ModelState.Clear();
                    return RedirectToAction("Index","Login");
                }
                
            }
            else
            {
                return View();
            }
            

        }


        
    }
}