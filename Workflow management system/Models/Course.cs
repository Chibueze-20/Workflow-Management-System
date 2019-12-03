using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Workflow_management_system.Models
{
     [Table("course_registration")]     
     public class CourseRegistration
     {
          [Key]
          public string CourseCode { get; set; }
          public string UserID { get; set; }
          public string DateRegistered { get; set; }
     }
     [Table("course")]
     public class Course
     {
          [Key]
          [Required]
          public string CourseCode { get; set; }
          [Required]
          public string CourseTitle { get; set; }
     }
}