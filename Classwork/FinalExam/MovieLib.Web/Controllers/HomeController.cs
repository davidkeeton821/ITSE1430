using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLib.Web.Controllers
{
    public class HomeController : Controller
    {
        //CR1 David Keeton - Deployed database
        //CR1 David Keeton - Made Web project startup project
        
        public ActionResult Index ()
        {
            return View();
        }        
    }
}