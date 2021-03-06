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
    public class BookTypeController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: BookType
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tbl_BookType = db.tbl_BookType.Include(t => t.tbl_Users);
            return View(tbl_BookType.ToList());
        }

        // GET: BookType/Details/5
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
            tbl_BookType tbl_BookType = db.tbl_BookType.Find(id);
            if (tbl_BookType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BookType);
        }

        // GET: BookType/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserID", "Username");
            return View();
        }

        // POST: BookType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_BookType tbl_BookType)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            tbl_BookType.UserId = userid;
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                db.tbl_BookType.Add(tbl_BookType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbl_Users, "UserID", "Username", tbl_BookType.UserId);
            return View(tbl_BookType);
        }

        // GET: BookType/Edit/5
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
            tbl_BookType tbl_BookType = db.tbl_BookType.Find(id);
            if (tbl_BookType == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserID", "Username", tbl_BookType.UserId);
            return View(tbl_BookType);
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_BookType tbl_BookType)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            tbl_BookType.UserId = userid;
            if (ModelState.IsValid)
            {
                db.Entry(tbl_BookType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserID", "Username", tbl_BookType.UserId);
            return View(tbl_BookType);
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
