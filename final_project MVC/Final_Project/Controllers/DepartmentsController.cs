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
    public class DepartmentsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();


        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        //check departmemt is available
        public JsonResult IsDeptCodeAvailable(string DepartmentCode)
        {
            var dept = db.Departments.ToList();
            if (!dept.Any(x => x.DepartmentCode == DepartmentCode.ToUpper()))
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


        public JsonResult IsDeptNameAvailable(string DepartmentName)
        {
            var dept = db.Departments.ToList();
            if (!dept.Any(x => x.DepartmentName == DepartmentName))
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

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentCode,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                FlashMessage.Confirmation(department.DepartmentName+" Department Sucessfully Added !!");
                return RedirectToAction("Create");
            }

            return View(department);
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
