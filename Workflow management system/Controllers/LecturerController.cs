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
    public class LecturerController : Controller
    {
        private Csc502DBContext db = new Csc502DBContext();
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mail()
        {
            IList<Mail> mail = db.Mail.ToList();
            return View(mail);
        }

        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Compose(Mail mail)
        {

            if (ModelState.IsValid)
            {
                db.Mail.Add(mail);
                db.SaveChanges();
                return RedirectToAction("Mail");
            }
            return View();
        }

        public ActionResult MailDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail mail = db.Mail.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            return View(mail);
        }

        public ActionResult DeleteMail(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail mail = db.Mail.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            return View(mail);
        }

        [HttpPost, ActionName("DeleteMail")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mail mail = db.Mail.Find(id);
            db.Mail.Remove(mail);
            db.SaveChanges();
            return RedirectToAction("Mail");
        }

        public ActionResult Workflow()
        {
            IList<Workflow> workflow = db.Workflows.ToList();
            return View(workflow);
        }

        public ActionResult WorkflowDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workflow workflow = db.Workflows.Find(id);
            if (workflow == null)
            {
                return HttpNotFound();
            }
            return View(workflow);
        }

        public ActionResult Posts()
        {
            IList<Post> posts = db.Posts.ToList();
            return View(posts);
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {

            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Posts");
            }
            return View();
        }

        public ActionResult PostDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult DeletePost(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Confirmed(string id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Posts");
        }

        public ActionResult Approve(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workflow workflow = db.Workflows.Find(id);
            if (workflow == null)
            {
                return HttpNotFound();
            }
            return View(workflow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                ViewData["WorkflowID"] = workflow.WorkflowID;
                ViewData["WorkflowTypeID"] = workflow.WorkflowTypeID;
                ViewData["Value"] = workflow.Value;
                ViewData["approve"] = workflow.Approval;
                db.Entry(workflow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Workflow");
            }
            return View();
        }

        public ActionResult Reject(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workflow workflow = db.Workflows.Find(id);
            if (workflow == null)
            {
                return HttpNotFound();
            }
            return View(workflow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                ViewData["WorkflowID"] = workflow.WorkflowID;
                ViewData["WorkflowTypeID"] = workflow.WorkflowTypeID;
                ViewData["Value"] = workflow.Value;
                workflow.Approval = "Rejected";
                db.Entry(workflow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Workflow");
            }
            return View();
        }
    }
}