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
    public class teachingLoadsController : Controller
    {
        private DemonArtAcademyDBEntities db = new DemonArtAcademyDBEntities();

        // GET: teachingLoads
        public ActionResult Index()
        {
            var teachingLoads = db.teachingLoads.Include(t => t.courseTable).Include(t => t.lecturerTable);
            return View(teachingLoads.ToList());
        }

        // GET: teachingLoads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachingLoad teachingLoad = db.teachingLoads.Find(id);
            if (teachingLoad == null)
            {
                return HttpNotFound();
            }
            return View(teachingLoad);
        }

        // GET: teachingLoads/Create
        public ActionResult Create()
        {
            ViewBag.course = new SelectList(db.courseTables, "courseId", "courseName");
            ViewBag.lecturer = new SelectList(db.lecturerTables, "lecturerId", "fullName");
            return View();
        }

        // POST: teachingLoads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,course,lecturer")] teachingLoad teachingLoad)
        {
            if (ModelState.IsValid)
            {
                db.teachingLoads.Add(teachingLoad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course = new SelectList(db.courseTables, "courseId", "courseName", teachingLoad.course);
            ViewBag.lecturer = new SelectList(db.lecturerTables, "lecturerId", "fullName", teachingLoad.lecturer);
            return View(teachingLoad);
        }

        // GET: teachingLoads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachingLoad teachingLoad = db.teachingLoads.Find(id);
            if (teachingLoad == null)
            {
                return HttpNotFound();
            }
            ViewBag.course = new SelectList(db.courseTables, "courseId", "courseName", teachingLoad.course);
            ViewBag.lecturer = new SelectList(db.lecturerTables, "lecturerId", "fullName", teachingLoad.lecturer);
            return View(teachingLoad);
        }

        // POST: teachingLoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,course,lecturer")] teachingLoad teachingLoad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachingLoad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course = new SelectList(db.courseTables, "courseId", "courseName", teachingLoad.course);
            ViewBag.lecturer = new SelectList(db.lecturerTables, "lecturerId", "fullName", teachingLoad.lecturer);
            return View(teachingLoad);
        }

        // GET: teachingLoads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachingLoad teachingLoad = db.teachingLoads.Find(id);
            if (teachingLoad == null)
            {
                return HttpNotFound();
            }
            return View(teachingLoad);
        }

        // POST: teachingLoads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teachingLoad teachingLoad = db.teachingLoads.Find(id);
            db.teachingLoads.Remove(teachingLoad);
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
