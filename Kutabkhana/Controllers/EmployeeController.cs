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
    public class EmployeeController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var tbl_Employee = db.tbl_Employee.Include(t => t.tbl_Department).Include(t => t.tbl_Designation);
            return View(tbl_Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name");
            ViewBag.DesignationID = new SelectList(db.tbl_Designation, "DesignationID", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,UserID,FullName,FatherName,Email,ContactNo,Address,DesignationID,DepartmentID,IsActive,Description")] tbl_Employee tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Employee.Add(tbl_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.tbl_Designation, "DesignationID", "Name", tbl_Employee.DesignationID);
            return View(tbl_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.tbl_Designation, "DesignationID", "Name", tbl_Employee.DesignationID);
            return View(tbl_Employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,UserID,FullName,FatherName,Email,ContactNo,Address,DesignationID,DepartmentID,IsActive,Description")] tbl_Employee tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.tbl_Department, "DepartmentID", "Name", tbl_Employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.tbl_Designation, "DesignationID", "Name", tbl_Employee.DesignationID);
            return View(tbl_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            db.tbl_Employee.Remove(tbl_Employee);
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
