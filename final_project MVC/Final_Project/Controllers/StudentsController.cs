using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;
using Vereyon.Web;

namespace Final_Project.Controllers
{
    public class StudentsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        

        public JsonResult IsStudentEmailAvailable(string Email)
        {
            var students = db.Students.ToList();

            if (!students.Any(x => x.Email == Email))
            {
                // This show the error message of validation and stop the submit of the form
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // This will ignore the validation and the submit of the form is gone to take place.
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
       
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
              
            }
               return View(student);
            
        }

        
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,Email,ContactNo,Date,Address,DepartmentId,RegistrationId")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.RegistrationId = GenerateRegNo(student);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = student.StudentId });
               
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", student.DepartmentId);
            return View(student);
        }

        private string GenerateRegNo(Student student)
        {
            int id = db.Students.Count(s => (s.DepartmentId == student.DepartmentId)
                                            && (s.Date.Year == student.Date.Year)) + 1;

            Department aDepartment = db.Departments.Where(d => d.DepartmentId == student.DepartmentId).FirstOrDefault();
            string registrationId = aDepartment.DepartmentCode + "-" + student.Date.Year + "-"+id.ToString("000");
            return registrationId;
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
