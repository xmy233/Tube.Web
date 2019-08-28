using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tube.Web.Model
{

    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
}
