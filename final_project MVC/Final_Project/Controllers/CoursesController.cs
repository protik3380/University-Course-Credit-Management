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
using Vereyon.Web;

namespace Final_Project.Controllers
{
    public class CoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        
        public JsonResult IsCourseCodeAvailable(string CourseCode)
        {
            return Json(!db.Courses.Any(x => x.CourseCode == CourseCode),
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsCourseNameAvailable(string CourseName)
        {
            return Json(!db.Courses.Any(x => x.CourseName == CourseName),
                JsonRequestBehavior.AllowGet);
        }
       
        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                FlashMessage.Confirmation(course.CourseName+" Course Sucessfully Added !!");
                return RedirectToAction("Create");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }
        public ActionResult UnassignCourses()
        {
            return View();
        }
        public JsonResult UnassignAllCourses(bool name)
        {
            var courses = db.Courses.Where(c => c.Status == true).ToList();
            var enrollCourses = db.EnrollCourses.Where(s=>s.IsEnroll==true).ToList();
            var teachers = db.AssignCourses.ToList();                   
            if (courses.Count == 0 && enrollCourses.Count == 0 )
            {
                return Json(false);
            }
            else
            {
                foreach (var course in courses)
                {
                    course.Status = false;
                    course.AssignTo = "";
                    db.Courses.AddOrUpdate(course);
                    db.SaveChanges();
                }

                foreach (var enrollCourse in enrollCourses)
                {
                    enrollCourse.GradeName = null;
                    enrollCourse.IsEnroll = false;
                    db.EnrollCourses.AddOrUpdate(enrollCourse);
                    db.SaveChanges();

                }
                foreach (var teacher in teachers)
                {
                    teacher.RemainingCredit = teacher.TakenCredit;
                    teacher.Teacher.RemainingCredit = teacher.TakenCredit;
                    db.AssignCourses.AddOrUpdate(teacher);
                    db.Teachers.AddOrUpdate(teacher.Teacher);
                    db.SaveChanges();
                }

                return Json(true);

            }
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
