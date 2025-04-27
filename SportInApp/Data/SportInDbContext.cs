using Microsoft.EntityFrameworkCore;
using SportInApp.Models;

namespace SportInApp.Data
{
    public class SportInDbContext : DbContext
    {
        public SportInDbContext(DbContextOptions<SportInDbContext> options)
            : base(options)
        {
        }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
