using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstEF.Models.data;
using Microsoft.Ajax.Utilities;

namespace CodeFirstEF.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreDB _db=new MusicStoreDB();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var album1 = _db.Albums.First();
            var artists = _db.Artists.ToList();
            _db.Students.Add(new Student() {Id = 1, Name = "kumanan"});
            _db.SaveChanges();
            return View();
        }

       
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
