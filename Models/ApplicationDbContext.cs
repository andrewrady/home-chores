using Microsoft.EntityFrameworkCore;

namespace homeChores.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Chore> Chore { get; set; }
    }
}