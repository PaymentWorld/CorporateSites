using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Codebase.Website.Models;

namespace Codebase.Website.Controllers
{
    public class products_servicesController : Controller
    {
        //
        // GET: /products-services/

        public ActionResult index(string type)
        {                        
            return View(new ProductsServicesViewModel(type));
        }
        
        #region " GET: /products-services/terminals "

        public ActionResult terminals(string type, string model)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (!string.IsNullOrEmpty(model))                
                    return View(model);                

                return View(type);
            }

            return View();
        }

        #endregion

    }
}
