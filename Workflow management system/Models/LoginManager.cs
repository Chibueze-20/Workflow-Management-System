using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workflow_management_system.Models
{
     public class LoginModel
     {
          [Key]
          [Required]
          [Display(Name ="Identity Code")]
          public string UserID { get; set; }
          [Required]
          [Display(Name = "Email")]
          [EmailAddress]
          public string EmailAddress { get; set; }
          [Required]
          [DataType(DataType.Password)]
          [MinLength(6)]
          [Display(Name = "Password")]
          public string Password { get; set; }
          [Required]
          public string Access { get; set; }
     }
     public class LoginManager
     {
          private object user;
          private string loginaccess;
          private DateTime loginTime;
          public LoginManager(object user,string access)
          {
               this.user = user;
               this.loginaccess = access;
               loginTime = DateTime.Now;
          }
          public object User { get { return user; } }
          public string LoginAccess { get { return loginaccess; } }
          public DateTime LoginTime { get { return loginTime; } }
          public static LoginManager Account { get; set; }
          public static LoginManager Login(object user,string access)
          {

               return new LoginManager(user, access);

          }
     }
}