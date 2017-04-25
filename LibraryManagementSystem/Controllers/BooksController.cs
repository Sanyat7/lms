using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,YearOfPublication,Isbn,PublisherId,Details,Penalty")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,YearOfPublication,Isbn,PublisherId,Details,Penalty")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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

        //For the Authors
        public ActionResult Authors(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult EditAuthors(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            PopulateAssignedAuthorData(book);
            return View(book);
        }
        private void PopulateAssignedAuthorData(Book book)
        {
            var allAuthors = db.Authors;
            var bookAuthors = new HashSet<int>(book.Authors.Select(s => s.Id));
            var viewModel = new List<AssignedAuthorData>();
            foreach (var author in allAuthors)
            {
                viewModel.Add(new AssignedAuthorData
                {
                    AuthorId = author.Id,
                    Name = author.FirstName + " " + author.MiddleName + " " + author.LastName,
                    Assigned = bookAuthors.Contains(author.Id)
                });
            }
            ViewBag.Authors = viewModel;
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthors(int? id, string[] selectedAuthors)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookToUpdate = db.Books
               .Include(i => i.Authors)
               .Where(i => i.Id == id)
               .Single();

            try
            {
                UpdateBookAuthor(selectedAuthors, bookToUpdate);

                db.SaveChanges();

                return RedirectToAction("Authors", new { id = id });
            }
            catch (Exception /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again!!");
            }

            PopulateAssignedAuthorData(bookToUpdate);
            return View(bookToUpdate);
        }

        private void UpdateBookAuthor(string[] selectedAuthors, Book bookToUpdate)
        {
            if (selectedAuthors == null)
            {
                bookToUpdate.Authors = new List<Author>();
                return;
            }

            var selectedAuthorsHS = new HashSet<string>(selectedAuthors);
            var bookAuthors = new HashSet<int>
                (bookToUpdate.Authors.Select(c => c.Id));
            foreach (var author in db.Authors)
            {
                if (selectedAuthorsHS.Contains(author.Id.ToString()))
                {
                    if (!bookAuthors.Contains(author.Id))
                    {
                        bookToUpdate.Authors.Add(author);
                    }
                }
                else
                {
                    if (bookAuthors.Contains(author.Id))
                    {
                        bookToUpdate.Authors.Remove(author);
                    }
                }
            }
        }
    }
}
