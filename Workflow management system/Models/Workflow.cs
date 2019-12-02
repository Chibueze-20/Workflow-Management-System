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

}