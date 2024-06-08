using BD_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        { }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Projects> Project { get; set; }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=bdback.db");

    }
}
