using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Workflow_management_system.Models
{
    [Table("workflow")]
    public class Workflow
    {
        [Key]
        [Required]
        public string WorkflowID { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string WorkflowTypeID { get; set; }
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Display(Name = "Approval")]
        public string Approval { get; set; }

        [Display(Name ="Student")]
        public string UserID { get; set; }
    }

     [Table("workflow_view")]
     public class WorkflowView
     {
          [Key]
          public string WorkflowID { get; set; }
          public string RequestType { get; set; }
          public string Value { get; set; }
          public string Approval { get; set; }
          public string UserID { get; set; }
     }
    [Table("workflow_type")]
    public class WorkflowType
    {
        [Key]
        [Required]
        public string WorkflowTypeID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Requirements")]
        public string Requirements { get; set; }
    }
     public class WorkflowRequirements
     {
          public string type { get; set; }
          public string description { get; set; }
     }
     public class WorkflowTemplate
     {
          [Key]
          public string WorkflowTypeID { get; set; }
          public string Name { get; set; }
          public List<WorkflowRequirements> Requirements { get; set; }
     }
     public class WorkflowData
     {
          public string description { get; set; }
          public string type { get; set; }
          public string value { get; set; }
     }
     public class WorkflowValue
     {
          public List<WorkflowData> data { get; set; }
          public List<Personel> personel { get; set; }
     }
     public class Personel
     {
          public string id { get; set; }
          public string status { get; set; }
          public Personel(string ID,string Status)
          {
               id = ID;
               status = Status;
          }
     }

}