using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Models.viewmodels
{
    public class ProfileFormViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAccount { get; set; }

        [Required]

        public string UserName { get; set; }

        [Display(Name = "phone number")]
        public string phone { get; set; }
    }
}
