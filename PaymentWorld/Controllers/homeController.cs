using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codebase.Website.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/

        public ActionResult index()
        {
            return View();
        }

        public ActionResult terms_of_use()
        {
            return View();
        }

        public ActionResult privacy_policy()
        {
            return View();
        }
    }
}
