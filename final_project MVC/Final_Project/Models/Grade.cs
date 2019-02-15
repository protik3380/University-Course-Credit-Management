using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        [Display(Name = "Grade")]
        public string GradeName { get; set; }
    }
}