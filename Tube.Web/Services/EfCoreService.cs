using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tube.Web.Data;
using Tube.Web.Model;

namespace Tube.Web.Services
{
    public class EfCoreService : IRepository<Student>
    {
        private readonly DataDbContext _context;

        public EfCoreService(DataDbContext context)
        {
            _context = context;
        }

        public Student Add(Student newModel)
        {
            _context.Student.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Student.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Student.Find(id);

        }
    }
}
