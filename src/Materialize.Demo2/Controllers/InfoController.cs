using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Materialize.Demo2.Controllers
{
    public class InfoController : Controller
    {
        public InfoController() {

        }
        
        public ActionResult Index() {
            return View();
        }

    }
}