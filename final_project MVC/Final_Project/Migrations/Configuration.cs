using Final_Project.Models;

namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project.Models.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Final_Project.Models.ProjectDbContext context)
        {
            //context.Semesters.AddOrUpdate(
            //    new Semester { SemesterName = "1st Semester" },
            //    new Semester { SemesterName = "2nd Semester" },
            //    new Semester { SemesterName = "3rd Semester" },
            //    new Semester { SemesterName = "4Th Semester" },
            //    new Semester { SemesterName = "5th Semester" },
            //    new Semester { SemesterName = "6th Semester" },
            //    new Semester { SemesterName = "7th Semester" },
            //    new Semester { SemesterName = "8th Semester" }

            //    );
            //context.Departments.AddOrUpdate(
            //    new Department { DepartmentCode = "CSE", DepartmentName = "Computer Science & Engineering" },
            //    new Department { DepartmentCode = "EEE", DepartmentName = "Electrical & Electronic Engineering" },
            //    new Department { DepartmentCode = "ETE", DepartmentName = "Electronic & Telecommunication Engineering" },
            //    new Department { DepartmentCode = "TE", DepartmentName = "Department Of Textile Engineering" },
            //    new Department { DepartmentCode = "BBA", DepartmentName = "Bachelor of Business Administration" }
            //    );
            //context.Designations.AddOrUpdate(
            //    new Designation { DesignationName = "Senior Lecturer" },
            //    new Designation { DesignationName = "Lecturer" },
            //    new Designation { DesignationName = "Professor" },
            //    new Designation { DesignationName = "Assistant Professor" }

            //    );
            //context.Grades.AddOrUpdate(
            //    new Grade { GradeName = "A+" },
            //    new Grade { GradeName = "A" },
            //    new Grade { GradeName = "A-" },
            //    new Grade { GradeName = "B+" },
            //    new Grade { GradeName = "B" },
            //    new Grade { GradeName = "B-" },
            //    new Grade { GradeName = "C+" },
            //    new Grade { GradeName = "C" },
            //    new Grade { GradeName = "C-" },
            //    new Grade { GradeName = "D+" },
            //    new Grade { GradeName = "D" },
            //    new Grade { GradeName = "D" },
            //    new Grade { GradeName = "F" }
            //    );
            //context.Days.AddOrUpdate(
            //    new Day { Name = "Saturday" },
            //    new Day { Name = "Sunday" },
            //    new Day { Name = "Monday" },
            //    new Day { Name = "Tuesday" },
            //    new Day { Name = "Wednesday" },
            //    new Day { Name = "Thursday" },
            //    new Day { Name = "Friday" }
            //    );

            //context.Rooms.AddOrUpdate(
            //    new Room { Name = "A-202" },
            //    new Room { Name = "A-203" },
            //    new Room { Name = "A-204" },
            //    new Room { Name = "A-205" },
            //    new Room { Name = "AB-203" },
            //    new Room { Name = "AB-204" },
            //    new Room { Name = "AB-203-L" },
            //    new Room { Name = "AB-204-L" }

            //    );
        }
    }
}
