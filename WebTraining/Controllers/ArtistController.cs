using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraining.Models.data;

namespace WebTraining.Controllers
{
    public class ArtistController : Controller
    {
        //
        // GET: /Artist/

        public ActionResult Index()
        {
            using (var ctx = new ChinookEntities())
            {
                var artistCollection = ctx.Artists.OrderByDescending(t => t.ArtistId).ToList();
                return View(artistCollection);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var ctx = new ChinookEntities())
            {
                var artist = ctx.Artists.Single(t => t.ArtistId == id);
                return View(artist);
            }
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            using (var ctx = new ChinookEntities())
            {
                var a = ctx.Artists.Single(t => t.ArtistId == artist.ArtistId);
                a.Name = artist.Name;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var ctx = new ChinookEntities())
            {
                var artist = ctx.Artists.Single(t => t.ArtistId == id);
                return View(artist);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new ChinookEntities())
            {
                var artist = ctx.Artists.Single(t => t.ArtistId == id);
                ctx.Artists.Remove(artist);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            using (var ctx = new ChinookEntities())
            {
                var id = ctx.Artists.OrderByDescending(t => t.ArtistId).First().ArtistId;
                artist.ArtistId = ++id;
                ctx.Artists.Add(artist);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        
    }
}
