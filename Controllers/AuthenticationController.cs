using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPProject.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var user = Request.QueryString["user"];
            if (!UserList.user.ContainsKey(user))
            {
                return View("Index");
            }
            FormsAuthentication.SetAuthCookie(user, true);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}