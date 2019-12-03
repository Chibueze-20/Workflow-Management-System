using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Workflow_management_system.Models
{
    public class User
    {
    }

    [Table("student")]
    public class Student
    {
        [Key]
        [Required]
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
        [Display(Name = "Level")]
        public int Level { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
    }
    
    [Table("web_admin")]
    public class Web_admin
    {
        [Key]
        [Required]
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
    }
    [Table("admin")]
    public class Admin
    {
        [Key]
        [Required]
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
        [Display(Name ="Role")]
        public string Type { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

    }

    public class Csc502DBContext : DbContext
    {
        public Csc502DBContext() : base(nameOrConnectionString: "DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasKey(l => l.id);
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Web_admin> WebAdmins { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<WorkflowType> Types { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}