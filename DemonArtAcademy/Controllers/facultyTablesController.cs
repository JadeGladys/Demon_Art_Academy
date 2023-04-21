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
    public class facultyTablesController : Controller
    {
        private DemonArtAcademyDBEntities db = new DemonArtAcademyDBEntities();

        // GET: facultyTables
        public ActionResult Index()
        {
            return View(db.facultyTables.ToList());
        }

        // GET: facultyTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyTable facultyTable = db.facultyTables.Find(id);
            if (facultyTable == null)
            {
                return HttpNotFound();
            }
            return View(facultyTable);
        }

        // GET: facultyTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: facultyTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "facultyId,facultyName")] facultyTable facultyTable)
        {
            if (ModelState.IsValid)
            {
                db.facultyTables.Add(facultyTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facultyTable);
        }

        // GET: facultyTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyTable facultyTable = db.facultyTables.Find(id);
            if (facultyTable == null)
            {
                return HttpNotFound();
            }
            return View(facultyTable);
        }

        // POST: facultyTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "facultyId,facultyName")] facultyTable facultyTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facultyTable);
        }

        // GET: facultyTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyTable facultyTable = db.facultyTables.Find(id);
            if (facultyTable == null)
            {
                return HttpNotFound();
            }
            return View(facultyTable);
        }

        // POST: facultyTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facultyTable facultyTable = db.facultyTables.Find(id);
            db.facultyTables.Remove(facultyTable);
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
