using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace WebTraining.Controllers
{
    public class UserController : Controller
    {

        public JsonResult CheckUsername(string userName)
        {
            if (UsernameExists(userName))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }


        private bool UsernameExists(string userName)
        {
            var userId = WebSecurity.GetUserId(userName);
            return userId > 0;
        }


    }
}
