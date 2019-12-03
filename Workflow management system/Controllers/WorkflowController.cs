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
    public class WorkflowController : Controller
    {
        private Csc502DBContext db = new Csc502DBContext();
        // GET: Workflow
        public ActionResult Index()
        {
            IList<WorkflowType> workflow = db.WorkflowTypes.ToList();
            return View(workflow);
        }

        public ActionResult CreateWorkflowType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorkflowType(WorkflowType workflowtype)
        {
            if (ModelState.IsValid)
            {
                ViewData["WorkflowTypeID"] = workflowtype.WorkflowTypeID;
                ViewData["Name"] = workflowtype.Name;
                ViewData["requirements"] = workflowtype.Requirements;
                db.WorkflowTypes.Add(workflowtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditWorkflowType(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowType type = db.WorkflowTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorkflowType(WorkflowType Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult WorkflowTypeDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowType type = db.WorkflowTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        public ActionResult DeleteWorkflowType(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkflowType type = db.WorkflowTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        [HttpPost, ActionName("DeleteWorkflowType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WorkflowType type = db.WorkflowTypes.Find(id);
            db.WorkflowTypes.Remove(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}