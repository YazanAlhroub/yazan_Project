using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Models.viewmodels
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
