using Microsoft.EntityFrameworkCore;

namespace CrudAsp.Models
{
    public class mydbcontext : DbContext
    {
        public mydbcontext(DbContextOptions<mydbcontext> options)
           : base(options)
        {
        }
        public DbSet<StudentInformation> StudentInformation { get; set; }
    }
}
