using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone3.Models;

namespace Capstone3.Controllers
{
    public class HomeController : Controller
    {
        public static List<Users> users = new List<Users>();
        public static List<Tasks> tasks = new List<Tasks>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            if (tasks.Count == 0)
            {
                Session["Message"] = "There are no tasks. How about you add a few!";
                return View();
            }

            Session["Tasks"] = tasks;

            return View();
        }

        [HttpPost]
        public ActionResult Login(Users u)
        {
            foreach (Users us in users)
            {
                if (us.Email ==u.Email && us.Password == u.Password)
                {
                    Session["LoggedIn"] = u.Email.ToUpper();

                    ViewBag.Tasks = tasks;

                    return View();
                }
            }

            Session["Error"] = "OOPS! The email and password you entered aren't in the system. Please try again.";

            return RedirectToAction("Index");
        }

        public ActionResult Register(Users u)
        {
            users.Add(u);
            Session["Error"] = "Congratulations! You are now a registered user. Please login.";

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["LoggedIn"] = null;
            Session["Error"] = "Goodbye!";
            return RedirectToAction("Index");
        }

        public ActionResult Task(Tasks t)
        {
            t.ID = Session["LoggedIn"].ToString();
            
            tasks.Add(t);
            ViewBag.Tasks = tasks;
            Session["Message"] = "";
            return RedirectToAction("Login");

        }
        
    }
}