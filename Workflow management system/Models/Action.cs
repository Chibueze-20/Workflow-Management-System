using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Workflow_management_system.Models
{
    public class Action
    {
    }

    [Table("mail")]
    public class Mail
    {
        [Key]
        [Required]
        public string MailID { get; set; }

        [Required]
        [Display(Name = "From")]
        public string From { get; set; }
        [Required]
        [Display(Name = "To")]
        public string To { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
        [Display(Name = "Read")]
        public Boolean Read { get; set; }
    }

    [Table("post")]
    public class Post
    {
        [Key]
        [Required]
        public string ID { get; set; }
        
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Broadcast")]
        public string Broadcast { get; set; }
    }
}