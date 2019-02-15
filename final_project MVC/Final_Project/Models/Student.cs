using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name field must not be empty!")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z]*$", ErrorMessage = "Only upper and lower case alphabets are allowed")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Remote("IsStudentEmailAvailable", "Students", ErrorMessage = "Email already exist!")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please provide correct Contact No format")]
        [Display(Name = "Contact No")]
        [RegularExpression(@"^\(?[+]([8]{2})([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Invalid Phone number. format (+8801XXXXXXXXX) area code-number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Date field must not be empty!")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select any Department!")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department d { get; set; }

        [Display(Name = "Reg. No")]
        public virtual string RegistrationId { get; set; }
    }
}