using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTraining.Controllers
{
    public class abcdeController : Controller
    {
        //
        // GET: /abcde/

        public ActionResult Index()
        {
            return Content("abcde");
        }

    }
}
