using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartexMVC.Controllers
{
    public class NavBarController : Controller
    {
        // GET: NavBar
        public ActionResult Index()
        {
            return PartialView("_NavBar");
        }
        public ActionResult AddTask()
        {
            return View();
        }
    }
}