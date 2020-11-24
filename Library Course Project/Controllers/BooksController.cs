using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_Course_Project.Models;
using PagedList;

namespace Library_Course_Project.Controllers
{
    public class BooksController : Controller
    {
        private BookLibraryContex db = new BookLibraryContex();

        // GET: Books
        public ActionResult Index(String searchTitle, int? searchGenreId, String searchWriter, String sortOrder, int? page)
        {
            var books = db.Books.Include(b => b.Genre).Include(b => b.Writer);
            ViewBag.TitleSearch = searchTitle;
            ViewBag.searchWriter = searchWriter;
            ViewBag.Genres = new SelectList(db.Genres, "GenreId", "GenreName");

            int curentPage = page ?? 1;
            int listNumberOfItems = 5;

            ViewBag.SortOrder = sortOrder;
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title-desc" : "";

            switch (sortOrder)
            {
                case "title-desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;

                default:
                    books = books.OrderBy(b => b.GenreId);
                    break;
            }





            if (!String.IsNullOrEmpty(searchTitle))
            {
                books = books.Where(b => b.Title.Contains(searchTitle));
            }

            if (!String.IsNullOrEmpty(searchWriter))
            {
                books = books.Where(b => b.Writer.FirstName.Contains(searchWriter));
            }

            if (searchGenreId.HasValue)
            {
                books = books.Where(b => b.GenreId == searchGenreId);
            }

            return View(books.ToPagedList(curentPage, listNumberOfItems));
        }

        // GET: Books/Details/5
        [Authorize(Roles = "Admin,User")]

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
        [Authorize(Roles = "Admin")]

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "FirstName","LastName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,ReleaseDate,WriterId,GenreId,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", book.GenreId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "FirstName","LastName", book.WriterId);
            return View(book);
        }
        [Authorize(Roles = "Admin")]

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
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", book.GenreId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "FirstName", book.WriterId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,ReleaseDate,WriterId,GenreId,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", book.GenreId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "FirstName", book.WriterId);
            return View(book);
        }
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]
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
    }
}
