using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Models
{
    public class Course
    {
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Course Code must be at least 5 characters long")]
        [Remote("IsCourseCodeAvailable", "Courses", ErrorMessage = "Course Code already exist.")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [Remote("IsCourseNameAvailable", "Courses", ErrorMessage = "Course name already exist.")]
       // [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Only upper and lower case alphabets are allowed")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course credit is required")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be within 0.5 to 5.0")]
        [Display(Name = "Credit")]
        public double Credit { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Please Select Semester")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        public virtual String AssignTo { get; set; }

        public bool Status { get; set; }
       // public bool IsEnroll { get; set; }

    }
}