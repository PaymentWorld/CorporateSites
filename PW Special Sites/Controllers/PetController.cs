using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PW_Special_Sites.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index(string q)
        {
            if (q != null)
            {
                foreach (var item in Properties.Settings.Default.AgentSettings)
                {
                    if (item.Split(',')[0].ToLower() == q.ToLower())
                    {
                        ViewBag.Email = item.Split(',')[0];
                        ViewBag.AppsLink = item.Split(',')[1];
                        ViewBag.Phone = item.Split(',')[2];
                    }
                } 
            }
            return View();
        }
    }
}