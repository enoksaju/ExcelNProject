using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiConection.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            ViewBag.Title = "Excel Nobleza";
            return View();
        }
    }
}