using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebTraining.Models.data;

namespace WebTraining.Controllers
{
    [AllowAnonymous]
    public class AlbumController : Controller
    {
        private readonly ChinookEntities ctx = new ChinookEntities();
        //
        // GET: /Album/
       
        public ActionResult Index()
        {
            List<Album> albumCollection = ctx.Albums.OrderByDescending(t => t.AlbumId).ToList();
            return View(albumCollection);
        }

       
        public JsonResult Detail(int id)
        {
            var album = ctx.Albums.Single(t => t.AlbumId == id);
            return Json(new{album.AlbumId,album.ArtistId,album.Title}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Custom(string q, int pageIndex, int pageSize)
        {
            if (pageSize == 0)
            {
                pageSize = 50;
            }

            int skipped = pageIndex*pageSize;
            ctx.Albums.Where(t => t.Title.Contains("a")).Skip(pageIndex).Take(pageSize);
            List<Album> albumCollection = ctx.Albums.OrderByDescending(t => t.AlbumId).ToList();
            return View(albumCollection);
        }

        public ActionResult Search(string q)
        {
            List<Album> albumCollection = ctx.Albums.Where(t => t.Title.Contains(q)).ToList();
            return View("Index", albumCollection);
        }

        public ActionResult Edit(int id)
        {
            Album album = ctx.Albums.Single(t => t.AlbumId == id);
            return View(album);
        }

        public ActionResult Details(int id)
        {
            Album album = ctx.Albums.Single(t => t.AlbumId == id);
            return View(album);
        }


        public ActionResult Delete(int id)
        {
            Album album = ctx.Albums.Single(t => t.AlbumId == id);
            ctx.Albums.Remove(album);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var album = new Album();
            ViewBag.ArtistId = new SelectList(ctx.Artists.ToList(), "ArtistId", "Name");
            ViewBag.StudentName = "Sriram";
            return View(album);
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (album.ArtistId == 0)
            {
                return View();
            }


            ctx.Albums.Add(album);
            int id = ctx.Albums.OrderByDescending(t => t.AlbumId).First().AlbumId;
            album.AlbumId = id + 1;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(Album album)
        {
            Album result = ctx.Albums.Single(t => t.AlbumId == album.AlbumId);
            result.Title = album.Title;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAlbum(Album album)
        {
            return Content("Updated");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ctx.Dispose();
        }
    }
}