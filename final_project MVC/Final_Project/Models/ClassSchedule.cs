using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class ClassSchedule
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Schedule { get; set; }

        public ClassSchedule(string courseCode, string courseName, string schedule)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Schedule = schedule;
        }
    }
}