using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kutabkhana_DBLayer;

namespace Kutabkhana.Controllers
{
    public class BookController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: Book
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tbl_Book = db.tbl_Book.Include(t => t.tbl_BookType).Include(t => t.tbl_Department).Include(t => t.tbl_Users);
            return View(tbl_Book.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Book tbl_Book = db.tbl_Book.Find(id);
            if (tbl_Book == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.BookTypeID = new SelectList(db.tbl_BookType, "BookTypeID", "Name", "0");
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", "0");
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", "0");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Book tbl_Book)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            tbl_Book.UserID = userid;
            if (ModelState.IsValid)
            {
                db.tbl_Book.Add(tbl_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookTypeID = new SelectList(db.tbl_BookType, "BookTypeID", "Name", tbl_Book.BookTypeID);
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Book.DepartmentID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Book.UserID);
            return View(tbl_Book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Book tbl_Book = db.tbl_Book.Find(id);
            if (tbl_Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookTypeID = new SelectList(db.tbl_BookType, "BookTypeID", "Name", tbl_Book.BookTypeID);
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Book.DepartmentID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Book.UserID);
            return View(tbl_Book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Book tbl_Book)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            tbl_Book.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookTypeID = new SelectList(db.tbl_BookType, "BookTypeID", "Name", tbl_Book.BookTypeID);
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Book.DepartmentID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Book.UserID);
            return View(tbl_Book);
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
