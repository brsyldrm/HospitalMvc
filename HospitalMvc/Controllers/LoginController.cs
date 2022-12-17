
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        [HttpGet]
        public ActionResult LoginPanel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPanel(User p)
        {
            Context c = new Context();
            var userinfo = c.Users.FirstOrDefault(x=>x.TC==p.TC && x.Passwd==p.Passwd);
            if (userinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(userinfo.UserID), false);
                Session["UserID"]= Convert.ToString(userinfo.UserID);
                if (userinfo.Rol==1)
                {

                    return RedirectToAction("Doctor", "Home");
                }
                if (userinfo.Rol == 2)
                {
                    return RedirectToAction("Patient", "Home");
                }
            }
            else 
            {
                return RedirectToAction("LoginPanel", "Login");
            }
            return View();
        }
    }
}