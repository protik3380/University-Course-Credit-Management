using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class EnrollCourseController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();
      

        // GET: EnrollCourse/Create
        public ActionResult Create()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.StudentList = db.Students.ToList();
            return View();
        }
        public ActionResult ViewResult()
        {
           // ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.StudentList = db.Students.ToList();
            return View();
        }
       
       
        public ActionResult SaveResult()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.StudentList = db.Students.ToList();
            ViewBag.GradeList = db.Grades.ToList();
            return View();
        }
        public JsonResult GetStudentById(string regNo)
        {
            var student = db.Students.Where(s => s.RegistrationId == regNo).ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesbyDept(int DepartmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == DepartmentId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCoursesbyRegNo(string regNo)
        {
            var courses = db.EnrollCourses.Where(c => c.RegistrationId == regNo && c.IsEnroll==true).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsEnrolled(string regNo, int courseId)
        {
            var enrollCourses = db.EnrollCourses.Where(s => s.RegistrationId == regNo && s.CourseId == courseId &&s.IsEnroll==true);
            int itm = enrollCourses.Count();
            if (itm == 0)
            {
                return Json(false);
            }
            return Json(true);
        }

        public ActionResult EnrollCoursetoStudent(EnrollCourse enrollCourse)
        {
            var enrollCourses = db.EnrollCourses.Where(s => s.RegistrationId == enrollCourse.RegistrationId && s.CourseId == enrollCourse.CourseId).ToList();            
            int itm = enrollCourses.Count();         
            
            if (itm == 1)
            {

                //keep previous id and date........cmmt crrent date..
                var id = enrollCourses[0].EnrollCourseId;
               // var date = enrollCourses[0].EnrollDate;
                enrollCourse.EnrollCourseId = id;
               // enrollCourse.EnrollDate = date;


                enrollCourse.IsEnroll = true;
                db.EnrollCourses.AddOrUpdate(enrollCourse);
            }
            else
            {

                enrollCourse.IsEnroll = true;
                db.EnrollCourses.Add(enrollCourse);
            }

            db.SaveChanges();
            return Json(true);
        }

        public ActionResult EnrollCoursetoStudent1(EnrollCourse enrollCourse)
        {
            var enrollCourses = db.EnrollCourses.Where(s => s.RegistrationId == enrollCourse.RegistrationId && s.CourseId == enrollCourse.CourseId).ToList();
            int itm = enrollCourses.Count();
            if (itm == 1)
            {
                var id = enrollCourses[0].EnrollCourseId;
                var date = enrollCourses[0].EnrollDate;
                enrollCourse.EnrollCourseId = id;
                enrollCourse.EnrollDate = date;
                enrollCourse.IsEnroll = true;
                db.EnrollCourses.AddOrUpdate(enrollCourse);
            }
            else
            {
                enrollCourse.IsEnroll = true;
              //  db.EnrollCourses.Add(enrollCourse);
                db.EnrollCourses.AddOrUpdate(enrollCourse);
            }

            db.SaveChanges();
            return Json(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
