using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ExcelNoblezaWebApp.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize()]
        public ActionResult Permisos() {
            return View();
        }

        [Authorize()]
        public ActionResult OrdenTrabajo()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Usuarios()
        {
            return View();
        } 
    }
}