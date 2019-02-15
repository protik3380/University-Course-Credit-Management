using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class RoomAllocation
    {
        public int RoomAllocationId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int DayId { get; set; }
        public virtual Day Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Status { get; set; }
    }
}