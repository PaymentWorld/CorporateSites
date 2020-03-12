using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codebase.Website.Pw.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index(string agent)
        {

            return View();
        }
    }
}