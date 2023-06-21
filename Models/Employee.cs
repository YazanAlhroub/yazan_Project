using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required(ErrorMessage ="enter employee name")]
       public string EmployeeName { get; set; }

        [Required(ErrorMessage = "enter a country")]
        public string country { get; set; }

        [Required(ErrorMessage = "enter employee Email")]
        public string Email { get; set; }
    }
}
