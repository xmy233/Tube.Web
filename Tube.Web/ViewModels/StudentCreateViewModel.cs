using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tube.Web.Model;

namespace Tube.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
