using Microsoft.EntityFrameworkCore;
using WebApplicationNew.Models.Entities;

namespace WebApplicationNew.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options): base(Options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
