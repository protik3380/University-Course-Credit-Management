using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class AssignCourse
    {
        public int AssignCourseId { set; get; }

        

        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        
        public virtual Department Department { get; set; }

        [Display(Name = "Teacher Name")]
        public int TeacherId { set; get; }
        public virtual Teacher Teacher { get; set; }
        [DefaultValue(0.0)]
        public virtual double TakenCredit { set; get; }
        [DefaultValue(0.0)]
        public virtual double RemainingCredit { set; get; } 
        [Display(Name = "Course Code")]
        public int CourseId { set; get; }
        public virtual Course Course { get; set; }
    }
}