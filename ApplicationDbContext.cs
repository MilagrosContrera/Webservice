using Microsoft.EntityFrameworkCore;

namespace TuProyecto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define tus entidades como DbSet aquí
        public DbSet<Student> Students { get; set; }
    }
}
