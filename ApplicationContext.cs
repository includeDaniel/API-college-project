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
        public DbSet<ProjectsModel> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>().HasKey(c => c.Id);
            modelBuilder.Entity<ProjectsModel>().HasKey(c => c.Id);
            modelBuilder.Entity<ContactUsModel>().HasKey(c => c.Id);

            modelBuilder.Entity<ClientModel>()
                .HasMany(e => e.Projects)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .IsRequired();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=bdback.db");
    }
}
