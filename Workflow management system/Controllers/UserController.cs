using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow_management_system.Models;

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
    }
}