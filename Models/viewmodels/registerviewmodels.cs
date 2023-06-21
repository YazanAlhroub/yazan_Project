using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Models.viewmodels
{
    public class registerviewmodels
    {
        [Required]
        [EmailAddress]
        public string EmailAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="password and confirm not match....")]
        public string confirmpassword { get; set; }

        [Display(Name ="phone number")]
        public string phone { get; set; }
    }
}
