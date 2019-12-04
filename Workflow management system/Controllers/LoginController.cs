using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow_management_system.Models;

namespace Workflow_management_system.Controllers
{
    public class LoginController : Controller
    {
          private Csc502DBContext db = new Csc502DBContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel logindetails)
        {
               object User = null;
               if (logindetails.Access=="Student")
               {
                    User = db.Students.Where(stu => stu.EmailAddress == logindetails.EmailAddress && stu.Password == logindetails.Password && stu.UserID == logindetails.UserID);
               }
               else if (logindetails.Access == "Lecturer")
               {
                    User = db.Admins.Where(stu => stu.EmailAddress == logindetails.EmailAddress && stu.Password == logindetails.Password && stu.UserID == logindetails.UserID);
               }
               else if (logindetails.Access == "Admin")
               {
                    User = db.WebAdmins.Where(stu => stu.EmailAddress == logindetails.EmailAddress && stu.Password == logindetails.Password && stu.UserID == logindetails.UserID);
               }
               if (User == null)
               {
                   return View();
               }
               else
               {
                    LoginManager.Account = LoginManager.Login(User, logindetails.Access);
               }
               return RedirectToRoute(logindetails.Access);
        }
          
    }
}