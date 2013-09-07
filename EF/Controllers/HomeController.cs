using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string q)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            using (var ctx=new ChinookEntities1())
            {
                var albums = ctx.Albums;

                foreach (var album in albums)
                {
                    
                }
                if (!string.IsNullOrWhiteSpace(q))
                {
                    var filteredAlbums = albums.Where(t => t.Title.StartsWith(q));
                    var finalList = filteredAlbums.ToList();
                }

                var normalList = albums.Take(50).ToList();

            }
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
