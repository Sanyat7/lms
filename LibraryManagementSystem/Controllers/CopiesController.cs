using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class CopiesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Copies
        public ActionResult Index()
        {
            var copies = db.Copies.Include(c => c.Book).Include(c => c.Shelf);
            return View(copies.ToList());
        }

        // GET: Copies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copy copy = db.Copies.Find(id);
            if (copy == null)
            {
                return HttpNotFound();
            }
            return View(copy);
        }

        // GET: Copies/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name");
            ViewBag.ShelfId = new SelectList(db.Shelves, "Id", "Name");
            return View();
        }

        // POST: Copies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookId,CopyNumber,ShelfId,Available,AgeRestricted")] Copy copy)
        {
            if (ModelState.IsValid)
            {
                db.Copies.Add(copy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Name", copy.BookId);
            ViewBag.ShelfId = new SelectList(db.Shelves, "Id", "Name", copy.ShelfId);
            return View(copy);
        }

        // GET: Copies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copy copy = db.Copies.Find(id);
            if (copy == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name", copy.BookId);
            ViewBag.ShelfId = new SelectList(db.Shelves, "Id", "Name", copy.ShelfId);
            return View(copy);
        }

        // POST: Copies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookId,CopyNumber,ShelfId,Available,AgeRestricted")] Copy copy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name", copy.BookId);
            ViewBag.ShelfId = new SelectList(db.Shelves, "Id", "Name", copy.ShelfId);
            return View(copy);
        }

        // GET: Copies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copy copy = db.Copies.Find(id);
            if (copy == null)
            {
                return HttpNotFound();
            }
            return View(copy);
        }

        // POST: Copies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Copy copy = db.Copies.Find(id);
            db.Copies.Remove(copy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
