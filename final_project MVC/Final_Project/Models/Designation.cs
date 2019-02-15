using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }

        [Display(Name = "Designation")]
        public string DesignationName { get; set; }
    }
}