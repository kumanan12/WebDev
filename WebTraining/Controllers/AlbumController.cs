using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebTraining.Models.data;

namespace WebTraining.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/
        
        public ActionResult Index(string q)
        {
            using (var ctx=new ChinookEntities())
            {

                var albumCollection = ctx.Albums.OrderByDescending(t => t.AlbumId).ToList();
                return View(albumCollection);
            }
           
        }

        public ActionResult Search(string q)
        {
            using (var ctx = new ChinookEntities())
            {

                //var albumCollection=ctx.Albums.OrderByDescending(t => t.AlbumId).ToList();
                var albumCollection = ctx.Albums.Where(t => t.Title.Contains(q)).ToList();
                return View("Index",albumCollection);
            }

        }

        public ActionResult Edit(int id)
        {
            
            using (var ctx = new ChinookEntities())
            {
                var album = ctx.Albums.Single(t=>t.AlbumId==id);
                return View(album);
            }

        }

        public ActionResult Details(int id)
        {

            using (var ctx = new ChinookEntities())
            {
                var album = ctx.Albums.Single(t => t.AlbumId == id);
                return View(album);
            }

        }

       
        public ActionResult Delete(int id)
        {

            using (var ctx = new ChinookEntities())
            {
                var album = ctx.Albums.Single(t => t.AlbumId == id);
                ctx.Albums.Remove(album);
                ctx.SaveChanges();
               return  RedirectToAction("Index");
            }

        }

        public ActionResult Create()
        {
            using (var ctx = new ChinookEntities())
            {
                var album = new Album();
                ViewBag.ArtistId = new SelectList(ctx.Artists.ToList(), "ArtistId", "Name");
                ViewBag.StudentName = "Sriram";
                return View(album);
            }
           

        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (album.ArtistId == 0)
            {

                return View();
            }

           
            using (var ctx = new ChinookEntities())
            {
                ctx.Albums.Add(album);
                var id = ctx.Albums.OrderByDescending(t => t.AlbumId).First().AlbumId;
                album.AlbumId = id + 1;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

        }


      

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            using (var ctx = new ChinookEntities())
            {
                var result = ctx.Albums.Single(t => t.AlbumId == album.AlbumId);
                result.Title = album.Title;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult UpdateAlbum(Album album)
        {
            return Content("Updated"); 
        }
    }
}
