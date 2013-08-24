using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraining.Models.data;

namespace WebTraining.Controllers
{
    public class TrackController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        //
        // GET: /Track/

        public ActionResult Index()
        {
            var tracks = db.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType);

            return View(tracks.ToList());
        }

        //
        // GET: /Track/Details/5

        public ActionResult Details(int id = 0)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        //
        // GET: /Track/Create

        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name");
            return View();
        }

        //
        // POST: /Track/Create

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        //
        // GET: /Track/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsSriRamPresent = true;
            ViewBag.customerId = 10;
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        //
        // POST: /Track/Edit/5

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        //
        // GET: /Track/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        //
        // POST: /Track/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}