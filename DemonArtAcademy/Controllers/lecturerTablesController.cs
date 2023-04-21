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
    public class lecturerTablesController : Controller
    {
        private DemonArtAcademyDBEntities db = new DemonArtAcademyDBEntities();

        // GET: lecturerTables
        public ActionResult Index()
        {
            return View(db.lecturerTables.ToList());
        }

        // GET: lecturerTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturerTable lecturerTable = db.lecturerTables.Find(id);
            if (lecturerTable == null)
            {
                return HttpNotFound();
            }
            return View(lecturerTable);
        }

        // GET: lecturerTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lecturerTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lecturerId,fullName,lecturerAddress,lecturerGender,lecturerPhone,lecturerEmail")] lecturerTable lecturerTable)
        {
            if (ModelState.IsValid)
            {
                db.lecturerTables.Add(lecturerTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lecturerTable);
        }

        // GET: lecturerTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturerTable lecturerTable = db.lecturerTables.Find(id);
            if (lecturerTable == null)
            {
                return HttpNotFound();
            }
            return View(lecturerTable);
        }

        // POST: lecturerTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lecturerId,fullName,lecturerAddress,lecturerGender,lecturerPhone,lecturerEmail")] lecturerTable lecturerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecturerTable);
        }

        // GET: lecturerTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturerTable lecturerTable = db.lecturerTables.Find(id);
            if (lecturerTable == null)
            {
                return HttpNotFound();
            }
            return View(lecturerTable);
        }

        // POST: lecturerTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lecturerTable lecturerTable = db.lecturerTables.Find(id);
            db.lecturerTables.Remove(lecturerTable);
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
