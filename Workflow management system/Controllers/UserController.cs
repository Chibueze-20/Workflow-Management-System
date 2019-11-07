using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Workflow_management_system.Models;
using System.Data.Entity;

namespace Workflow_management_system.Controllers
{
    public class UserController : Controller
    {
        private Csc502DBContext db = new Csc502DBContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lecturers()
        {
            IList<Admin> lecturers = db.Admins.ToList();
            return View(lecturers);
        }
        public ActionResult CreateLecturer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLecturer(Admin Lecturer)
        {

            if (ModelState.IsValid)
            {
                db.Admins.Add(Lecturer);
                db.SaveChanges();
                return RedirectToAction("Lecturers");
            }
            return View();
        }

        public ActionResult Students()
        {
            IList<Student> students = db.Students.ToList();
            return View(students);

        }

        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Students");
            }
            return View();
        }

        public ActionResult EditLecturer(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin lecturer = db.Admins.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLecturer(Admin lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Lecturers");
            }
            return View("Lecturers");
        }

        public ActionResult LecturerDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin lecturer = db.Admins.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        public ActionResult DeleteLecturer(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin lecturer = db.Admins.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        [HttpPost, ActionName("DeleteLecturer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Admin lecturer = db.Admins.Find(id);
            db.Admins.Remove(lecturer);
            db.SaveChanges();
            return RedirectToAction("Lecturers");
        }

        public ActionResult EditStudent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Students");
            }
            return View("Students");
        }

        public ActionResult StudentDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult DeleteStudent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Confirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Students");
        }
    }
}