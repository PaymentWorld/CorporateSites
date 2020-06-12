using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codebase.Website.Nmc.Controllers
{
    public class DataBreachController : Controller
    {
        // GET: DataBreach
        public ActionResult Index()
        {
            ViewBag.Video = ConfigurationManager.AppSettings["DataBreachVideo"];
            return View();
        }
        public ActionResult Video()
        {
            ViewBag.Video = ConfigurationManager.AppSettings["DataBreachVideo"];
            return View();
        }
    }
}