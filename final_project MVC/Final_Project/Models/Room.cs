using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Display(Name = "Room No")]
        public string Name { get; set; }
    }
}