using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemonArtAcademy.Models;

namespace DemonArtAcademy.Controllers
{
    public class departmentTablesController : Controller
    {
        private DemonArtAcademyDBEntities db = new DemonArtAcademyDBEntities();

        // GET: departmentTables
        public ActionResult Index()
        {
            var departmentTables = db.departmentTables.Include(d => d.facultyTable);
            return View(departmentTables.ToList());
        }

        // GET: departmentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmentTable departmentTable = db.departmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            return View(departmentTable);
        }

        // GET: departmentTables/Create
        public ActionResult Create()
        {
            ViewBag.faculty = new SelectList(db.facultyTables, "facultyId", "facultyName");
            return View();
        }

        // POST: departmentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "depId,depName,faculty")] departmentTable departmentTable)
        {
            if (ModelState.IsValid)
            {
                db.departmentTables.Add(departmentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.faculty = new SelectList(db.facultyTables, "facultyId", "facultyName", departmentTable.faculty);
            return View(departmentTable);
        }

        // GET: departmentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmentTable departmentTable = db.departmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.faculty = new SelectList(db.facultyTables, "facultyId", "facultyName", departmentTable.faculty);
            return View(departmentTable);
        }

        // POST: departmentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "depId,depName,faculty")] departmentTable departmentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.faculty = new SelectList(db.facultyTables, "facultyId", "facultyName", departmentTable.faculty);
            return View(departmentTable);
        }

        // GET: departmentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmentTable departmentTable = db.departmentTables.Find(id);
            if (departmentTable == null)
            {
                return HttpNotFound();
            }
            return View(departmentTable);
        }

        // POST: departmentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            departmentTable departmentTable = db.departmentTables.Find(id);
            db.departmentTables.Remove(departmentTable);
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
