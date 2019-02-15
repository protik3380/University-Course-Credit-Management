namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignCourse",
                c => new
                    {
                        AssignCourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        TakenCredit = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 20),
                        CourseName = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        AssignTo = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Semester", t => t.SemesterId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 7),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContactNo = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        TakenCredit = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.EnrollCourse",
                c => new
                    {
                        EnrollCourseId = c.Int(nullable: false, identity: true),
                        RegistrationId = c.String(),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        GradeName = c.String(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContactNo = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        RegistrationId = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.RoomAllocation",
                c => new
                    {
                        RoomAllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RoomAllocationId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Day", t => t.DayId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomAllocation", "RoomId", "dbo.Room");
            DropForeignKey("dbo.RoomAllocation", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.RoomAllocation", "DayId", "dbo.Day");
            DropForeignKey("dbo.RoomAllocation", "CourseId", "dbo.Course");
            DropForeignKey("dbo.EnrollCourse", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.EnrollCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.AssignCourse", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Teacher", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.AssignCourse", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.AssignCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "SemesterId", "dbo.Semester");
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Department");
            DropIndex("dbo.RoomAllocation", new[] { "DayId" });
            DropIndex("dbo.RoomAllocation", new[] { "RoomId" });
            DropIndex("dbo.RoomAllocation", new[] { "CourseId" });
            DropIndex("dbo.RoomAllocation", new[] { "DepartmentId" });
            DropIndex("dbo.Student", new[] { "DepartmentId" });
            DropIndex("dbo.EnrollCourse", new[] { "Student_StudentId" });
            DropIndex("dbo.EnrollCourse", new[] { "CourseId" });
            DropIndex("dbo.Teacher", new[] { "DepartmentId" });
            DropIndex("dbo.Teacher", new[] { "DesignationId" });
            DropIndex("dbo.Course", new[] { "SemesterId" });
            DropIndex("dbo.Course", new[] { "DepartmentId" });
            DropIndex("dbo.AssignCourse", new[] { "CourseId" });
            DropIndex("dbo.AssignCourse", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourse", new[] { "DepartmentId" });
            DropTable("dbo.Room");
            DropTable("dbo.RoomAllocation");
            DropTable("dbo.Grade");
            DropTable("dbo.Student");
            DropTable("dbo.EnrollCourse");
            DropTable("dbo.Day");
            DropTable("dbo.Designation");
            DropTable("dbo.Teacher");
            DropTable("dbo.Semester");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
            DropTable("dbo.AssignCourse");
        }
    }
}
