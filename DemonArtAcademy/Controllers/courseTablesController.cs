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
    public class courseTablesController : Controller
    {
        private DemonArtAcademyDBEntities db = new DemonArtAcademyDBEntities();

        // GET: courseTables
        public ActionResult Index()
        {
            var courseTables = db.courseTables.Include(c => c.departmentTable);
            return View(courseTables.ToList());
        }

        // GET: courseTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courseTable courseTable = db.courseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // GET: courseTables/Create
        public ActionResult Create()
        {
            ViewBag.department = new SelectList(db.departmentTables, "depId", "depName");
            return View();
        }

        // POST: courseTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseId,courseName,credits,department")] courseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.courseTables.Add(courseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department = new SelectList(db.departmentTables, "depId", "depName", courseTable.department);
            return View(courseTable);
        }

        // GET: courseTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courseTable courseTable = db.courseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.department = new SelectList(db.departmentTables, "depId", "depName", courseTable.department);
            return View(courseTable);
        }

        // POST: courseTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseId,courseName,credits,department")] courseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department = new SelectList(db.departmentTables, "depId", "depName", courseTable.department);
            return View(courseTable);
        }

        // GET: courseTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courseTable courseTable = db.courseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // POST: courseTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            courseTable courseTable = db.courseTables.Find(id);
            db.courseTables.Remove(courseTable);
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
