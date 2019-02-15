using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        
        [Required(ErrorMessage = "Department Code is Required")]
        [Display(Name = "Department Code ")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department code must be two 2 to 7 characters long")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z]*$", ErrorMessage = "Department Code Should Contains Only Upper and Lower Case Alphabets!!")]
        [Remote("IsDeptCodeAvailable", "Departments", ErrorMessage = "Department Code already exist.")]
        
        public String DepartmentCode { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [Display(Name = "Department Name ")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_&]*$", ErrorMessage = "Department Name Should Not Have Numaric Value Or other Special Character!!")]
        [Remote("IsDeptNameAvailable", "Departments", ErrorMessage = "Department Name already exist.")]
        public String DepartmentName { get; set; }


    }
}