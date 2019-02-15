using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }

        [Display(Name = "Semester")]
        public string SemesterName { get; set; }
    }
}