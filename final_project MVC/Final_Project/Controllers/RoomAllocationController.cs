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
    public class RoomAllocationController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: RoomAllocation
        public ActionResult Index()
        {
            ViewBag.departments = db.Departments.ToList();
            return View();
        }

       

        // GET: RoomAllocation/Create
        public ActionResult Create()
        {
            ViewBag.courses = db.Courses.Where(s => s.Status == true).ToList();
            ViewBag.departments = db.Departments.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            ViewBag.Days = db.Days.ToList();
            return View();
        }

        

        public JsonResult SaveRoomSchedule(RoomAllocation roomAllocation)
        {
            var scheduleList = db.RoomAllocations.Where(t => t.RoomId == roomAllocation.RoomId && t.DayId == roomAllocation.DayId && t.Status == "Allocated").ToList();
            if (scheduleList.Count==0)
            {
                roomAllocation.Status = "Allocated";
                db.RoomAllocations.Add(roomAllocation);
                db.SaveChanges();
                return Json(true);
            }
            else
            {
                bool state = false;
                foreach (var allocation in scheduleList)
                {
                    if ((roomAllocation.StartTime >= allocation.StartTime && roomAllocation.StartTime < allocation.EndTime)
                        || (roomAllocation.EndTime > allocation.StartTime && roomAllocation.EndTime <= allocation.EndTime) && roomAllocation.Status == "Allocated")
                    {
                        state = true;
                    }
                }

                if (state==false)
                {
                    roomAllocation.Status = "Allocated";
                    db.RoomAllocations.Add(roomAllocation);
                    db.SaveChanges();
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }


            }
        }
        public JsonResult GetClassScheduleInfo(int deptId)
        {
            var courses = db.Courses.Where(t => t.DepartmentId == deptId).ToList();
            List<ClassSchedule> classSchedules = new List<ClassSchedule>();

            foreach (var course in courses)
            {
                string schedule = "";
                int counter = 0;
                var courseSchedules = db.RoomAllocations.Where(t => t.DepartmentId == course.DepartmentId && t.CourseId == course.CourseId && t.Status == "Allocated").ToList();

                foreach (var courseSchedule in courseSchedules)
                {
                    if (counter != 0)
                    {
                        schedule += "; ";
                    }
                    schedule += "R. No : " + courseSchedule.Room.Name + ", " + courseSchedule.Day.Name.Substring(0, 3) + ", ";
                    int hour, minute;
                    string p = "AM";
                    int startTime = courseSchedule.StartTime;
                    hour = startTime / 60;
                    minute = startTime - (hour * 60);
                    if (startTime >= 720)
                    {
                        hour -= 12;
                        if (hour == 0) hour = 12;
                        p = "PM";
                    }
                    schedule += hour + ":" + minute.ToString("00") + " " + p + " - ";
                    int endTime = courseSchedule.EndTime;
                    hour = endTime / 60;
                    minute = endTime - (hour * 60);
                    p = "AM";
                    if (endTime >= 720)
                    {
                        hour -= 12;
                        if (hour == 0) hour = 12;
                        p = "PM";
                    }
                    schedule += hour + ":" + minute.ToString("00") + " " + p;
                    counter++;
                }
                if (schedule == "") schedule = "Not Scheduled Yet.";
                ClassSchedule classSchedule = new ClassSchedule(course.CourseCode, course.CourseName, schedule);
                classSchedules.Add(classSchedule);
            }
            return Json(classSchedules, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDeptId(int deptId)
        {
            var courses = db.Courses.Where(t => t.DepartmentId == deptId && t.Status==true).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
       

        public ActionResult UnallocateRoom()
        {
            return View();
        }
        public JsonResult UnallocateAllRooms(bool name)
        {
            var roomInfo = db.RoomAllocations.Where(r => r.Status == "Allocated").ToList();
            if (roomInfo.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var room in roomInfo)
                {
                    room.Status = null;
                    db.RoomAllocations.AddOrUpdate(room);
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
