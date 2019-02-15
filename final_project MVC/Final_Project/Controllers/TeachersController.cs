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
    public class TeachersController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();


        public JsonResult IsTeacherEmailAvailable(string Email)
        {
            var teachers = db.Teachers.ToList();
          
            if (!teachers.Any(x => x.Email == Email))
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
      

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,TeacherName,Address,Email,ContactNo,DesignationId,DepartmentId,TakenCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.RemainingCredit = teacher.TakenCredit;
                db.Teachers.Add(teacher);
                db.SaveChanges();
                FlashMessage.Confirmation("Teacher Sucessfully Added !!");
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", teacher.DesignationId);
            return View(teacher);
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
