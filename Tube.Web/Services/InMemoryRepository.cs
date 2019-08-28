using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tube.Web.Model;

namespace Tube.Web.Services
{
    public class InMemoryRepository : IRepository<Student>
    {
        private readonly List<Student> _students;

        public InMemoryRepository()
        {
            _students = new List<Student>
            {

                new Student
                {
                    Id = 1,
                    FirstName = "Nike",
                    LastName = "Carter",
                    Gender=Gender.女,
                    BirthDate = new DateTime(1998, 1, 4)
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Kevin",
                    LastName = "Richardson",
                    Gender=Gender.男,
                    BirthDate = new DateTime(1999, 10, 24)

                },
                new Student
                {
                    Id = 3,
                    FirstName = "Alea",
                    LastName = "Fadelat",
                    Gender=Gender.女,
                    BirthDate = new DateTime(2000, 5, 28)

                }
            };

        }

        public Student Add(Student newModel)
        {
            var maxId = _students.Max(p => p.Id);
            newModel.Id = maxId + 1;
            _students.Add(newModel);
            return newModel;
        }
  
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(x=>x.Id==id);
        }

        
    }
}
