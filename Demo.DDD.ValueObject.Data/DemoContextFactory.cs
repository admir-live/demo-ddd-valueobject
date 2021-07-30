using Demo.DDD.ValueObject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sample.Mutable.Process.Infrastructure.Database
{
    public class DemoContextFactory : IDesignTimeDbContextFactory<DemoContext>
    {
        public DemoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseSqlServer(connectionString: Constants.ConnectionString);
            return new DemoContext(options: optionsBuilder.Options);
        }
    }
}