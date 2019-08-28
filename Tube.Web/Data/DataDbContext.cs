using Microsoft.EntityFrameworkCore;
using Tube.Web.Model;

namespace Tube.Web.Data
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            :base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
