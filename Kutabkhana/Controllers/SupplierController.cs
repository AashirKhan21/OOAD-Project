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
    public class SupplierController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: Supplier
        public ActionResult Index()
        {
            var tbl_Supplier = db.tbl_Supplier.Include(t => t.tbl_Users);
            return View(tbl_Supplier.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Supplier tbl_Supplier = db.tbl_Supplier.Find(id);
            if (tbl_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username");
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,UserID,ContactNo,Email,Description")] tbl_Supplier tbl_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Supplier.Add(tbl_Supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Supplier.UserID);
            return View(tbl_Supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Supplier tbl_Supplier = db.tbl_Supplier.Find(id);
            if (tbl_Supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Supplier.UserID);
            return View(tbl_Supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,UserID,ContactNo,Email,Description")] tbl_Supplier tbl_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Supplier.UserID);
            return View(tbl_Supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Supplier tbl_Supplier = db.tbl_Supplier.Find(id);
            if (tbl_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Supplier tbl_Supplier = db.tbl_Supplier.Find(id);
            db.tbl_Supplier.Remove(tbl_Supplier);
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
