using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Students.Models
{
    [Table("Address")]
    public class Address
    {

        public Address() {
            StudentsId = 0;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Street")]
        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Street Name Is Reuired..!")]
        public String Street { get; set; }

        [Column("City")]
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Is Reuired..!")]
        public String City { get; set; }

        [Column("State")]
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Is Reuired..!")]
        public String State { get; set; }

        [Column("Country")]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Is Reuired..!")]
        public String Country { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Student Name Reuired..!")]
        public int StudentsId { get; set; }
    }

}