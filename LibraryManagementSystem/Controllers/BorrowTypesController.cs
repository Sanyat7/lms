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
    public class BorrowTypesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: BorrowTypes
        public ActionResult Index()
        {
            return View(db.BorrowTypes.ToList());
        }

        // GET: BorrowTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowType borrowType = db.BorrowTypes.Find(id);
            if (borrowType == null)
            {
                return HttpNotFound();
            }
            return View(borrowType);
        }

        // GET: BorrowTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Period")] BorrowType borrowType)
        {
            if (ModelState.IsValid)
            {
                db.BorrowTypes.Add(borrowType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrowType);
        }

        // GET: BorrowTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowType borrowType = db.BorrowTypes.Find(id);
            if (borrowType == null)
            {
                return HttpNotFound();
            }
            return View(borrowType);
        }

        // POST: BorrowTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Period")] BorrowType borrowType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrowType);
        }

        // GET: BorrowTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowType borrowType = db.BorrowTypes.Find(id);
            if (borrowType == null)
            {
                return HttpNotFound();
            }
            return View(borrowType);
        }

        // POST: BorrowTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowType borrowType = db.BorrowTypes.Find(id);
            db.BorrowTypes.Remove(borrowType);
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
