using BD_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        { }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ContactUsModel> ContactUs { get; set; }
        public DbSet<ProjectsModel> Project { get; set; }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=bdback.db");

        internal Task<IEnumerable<ClientModel>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
