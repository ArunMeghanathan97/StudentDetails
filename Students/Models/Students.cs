using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Required]
        public int StudentsId { get; set; } 

        [Column("Name")]
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Student Name Is Reuired..!")]
        public String Name { get; set; }

        [Column("Mobile")]
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile Is Reuired..!")]
        public String Mobile { get; set; }

        [Column("Email")]
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email ID Is Reuired..!")]
        [EmailAddress(ErrorMessage="Enter Valid Mail Id..!")]
        public String Email { get; set; }
    }
}