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
    public class PurchaseController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            var tbl_Purchase = db.tbl_Purchase.Include(t => t.tbl_Supplier).Include(t => t.tbl_Users);
            return View(tbl_Purchase.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Purchase tbl_Purchase = db.tbl_Purchase.Find(id);
            if (tbl_Purchase == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Purchase);
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.tbl_Supplier, "SupplierID", "SupplierName");
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username");
            return View();
        }

        // POST: Purchase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseID,PurchaseDate,UserID,PurchaseAmount,SupplierID")] tbl_Purchase tbl_Purchase)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Purchase.Add(tbl_Purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.tbl_Supplier, "SupplierID", "SupplierName", tbl_Purchase.SupplierID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Purchase.UserID);
            return View(tbl_Purchase);
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Purchase tbl_Purchase = db.tbl_Purchase.Find(id);
            if (tbl_Purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.tbl_Supplier, "SupplierID", "SupplierName", tbl_Purchase.SupplierID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Purchase.UserID);
            return View(tbl_Purchase);
        }

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,PurchaseDate,UserID,PurchaseAmount,SupplierID")] tbl_Purchase tbl_Purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.tbl_Supplier, "SupplierID", "SupplierName", tbl_Purchase.SupplierID);
            ViewBag.UserID = new SelectList(db.tbl_Users, "UserID", "Username", tbl_Purchase.UserID);
            return View(tbl_Purchase);
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Purchase tbl_Purchase = db.tbl_Purchase.Find(id);
            if (tbl_Purchase == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Purchase tbl_Purchase = db.tbl_Purchase.Find(id);
            db.tbl_Purchase.Remove(tbl_Purchase);
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
