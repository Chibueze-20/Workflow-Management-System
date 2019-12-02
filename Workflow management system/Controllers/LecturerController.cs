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
    }
}