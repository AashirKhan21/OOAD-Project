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
    public class UserTypeController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: UserType
        public ActionResult Index()
        {
            return View(db.tbl_UserType.ToList());
        }

        // GET: UserType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserType tbl_UserType = db.tbl_UserType.Find(id);
            if (tbl_UserType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserType);
        }

        // GET: UserType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTypeID,UserType")] tbl_UserType tbl_UserType)
        {
            if (ModelState.IsValid)
            {
                db.tbl_UserType.Add(tbl_UserType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_UserType);
        }

        // GET: UserType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserType tbl_UserType = db.tbl_UserType.Find(id);
            if (tbl_UserType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserType);
        }

        // POST: UserType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTypeID,UserType")] tbl_UserType tbl_UserType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_UserType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_UserType);
        }

        // GET: UserType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserType tbl_UserType = db.tbl_UserType.Find(id);
            if (tbl_UserType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserType);
        }

        // POST: UserType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_UserType tbl_UserType = db.tbl_UserType.Find(id);
            db.tbl_UserType.Remove(tbl_UserType);
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
