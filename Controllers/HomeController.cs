using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [SiteAuthProvider]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [SiteAuthProvider]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [SiteAuthProvider]
        public ActionResult Registration(Student? mdl)
        {
            ViewBag.Message = "Your Registration Page";
            return View();
        }

        public ActionResult RegistrationList()
        {
            List<Student> l1 = new();
            l1.Add(new Student()
            {
                firstname="jhai", lastname = "salvador", dob=DateTime.Parse("06/01/1990") , id = 0
            });

            var rn = new Random();
            for (int i = 0; i < 15; i++)
            {
                l1.Add(new Student()
                {
                    id=i+1,
                    firstname = "user - " + i+1,
                    lastname = "lastname - " + i+1,
                    dob = DateTime.Parse("06/01/" + rn.Next(1986, 2002))
                });
            }

            return PartialView("~/views/home/_RegistrationList.cshtml", l1);
        }

    }
}