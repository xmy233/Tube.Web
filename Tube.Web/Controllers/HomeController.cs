using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tube.Web.Model;
using Tube.Web.Services;
using Tube.Web.ViewModels;

namespace Tube.Web.Controllers
{
    //[Route("[Controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }



        public IActionResult Index()
        {
            
            var list = _repository.GetAll();
            var vms = list.Select(x=>new StudentViewModel
            {
                Id = x.Id,
                Name=$"{x.FirstName} {x.LastName}",
                Age=DateTime.Now.Subtract(x.BirthDate).Days / 365
            });
            var vm = new HomeIndexViewModel
            {
                Students =  vms
            };
            return View(vm);
            // string Name=this.ControllerContext.ActionDescriptor.ControllerName;
            //return Ok();
            // return Name;
            //return "Hello HomeController";
        }

        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if (student==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateViewModel student)
        {

            if (ModelState.IsValid)
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Gender = student.Gender
                };
                var newModel = _repository.Add(newStudent);

                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }
            else
            {
                return View( );
            }
           
        }

        
    }
}
