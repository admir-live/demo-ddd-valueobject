using Demo.DDD.ValueObject.Data.Model;
using Microsoft.EntityFrameworkCore;
using Sample.Mutable.Process.Infrastructure.Database.Configuration;

namespace Sample.Mutable.Process.Infrastructure.Database
{
    public sealed class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options: options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(configuration: new UserEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder: modelBuilder);
        }
    }
}