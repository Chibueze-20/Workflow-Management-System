﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow_management_system.Models;

namespace Workflow_management_system.Controllers
{
    public class StudentController : Controller
     {
          private Csc502DBContext db = new Csc502DBContext();
          // GET: Student
          public ActionResult Index()
        {
            return View();
        }

          //GET: posts
          public ActionResult Posts()
          {
               IList<string> boradcastlist = new List<string> { "all", "100 level", "csc 100", "csc 120" };
              List<Post> posts = db.Posts.Where(x => boradcastlist.Contains(x.Broadcast)).ToList();
               return View();
          }
          [HttpGet]
          public ActionResult CourseRegistration()
          {
               List<Course> courses = db.Courses.ToList();
               return View(courses);
          }
          [HttpPost]
          public ActionResult CourseRegistration(CourseRegistration coursereg)
          {
               if (ModelState.IsValid)
               {
                    coursereg.DateRegistered = DateTime.Today.ToShortDateString();
                    coursereg.UserID = "";
                    db.CourseRegistration.Add(coursereg);
                    db.SaveChanges();
                    ViewData["feedback message"] = "course sucessfully registerd";
                    ViewData["feedback class"] = "success";
                    return View();
               }
               else
               {
                    ViewData["feedback message"] = "Error registering course, try again";
                    ViewData["feedback class"] = "danger";
                    return View();
               }
               
          }
          [HttpGet]
          public ActionResult ViewCourseRegistration()
          {
               List<CourseRegistration> registration = db.CourseRegistration.Where(x => x.UserID == "" && (DateTime.Parse(x.DateRegistered).Year == DateTime.Today.Year)).ToList();
               List<Course> coursedetails = db.Courses.Where(x => registration.Exists(reg => reg.CourseCode == x.CourseCode)).ToList();
               return View(coursedetails);
          }
          [HttpPost]
          public ActionResult DeleteCourse(string id)
          {
               CourseRegistration reg = db.CourseRegistration.First(x => x.CourseCode == id && x.UserID == "");
               db.CourseRegistration.Remove(reg);
               db.SaveChanges();
               ViewData["feedback message"] = "Course removed sucessfully";
               ViewData["feedback class"] = "success";
               return View();

          }
          [HttpGet]
          public ActionResult Getworkflows()
          {
               List<WorkflowType> workflowtypes =  db.WorkflowTypes.ToList();
               return View(workflowtypes);
          }
          [HttpGet]
          public ActionResult CreateWorkflow(string id)
          {
               WorkflowType workflowtype = db.WorkflowTypes.First(wft => wft.WorkflowTypeID == id);
               WorkflowTemplate template = new WorkflowTemplate();
               template.Name = workflowtype.Name;
               template.WorkflowTypeID = workflowtype.WorkflowTypeID;
               var requirementsstring = (string)workflowtype.Requirements;
               using (var textreader = new StringReader(requirementsstring))
               {
                    using(var reader = new JsonTextReader(textreader))
                    {
                         template.Requirements = new JsonSerializer().Deserialize(reader, typeof(List<WorkflowRequirements>)) as List<WorkflowRequirements>;
                    }
               }
                    return View(template);
          }
    }
}