using System;
using System.Linq;
using System.Threading.Tasks;
using Demo.DDD.ValueObject.Data;
using Demo.DDD.ValueObject.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Mutable.Process.Infrastructure.Database;

namespace Demo.DDD.ValueObject
{
    internal class Program
    {
        private static readonly IServiceProvider ServiceProvider = ConfigureServices();

        private static async Task Main(string[] args)
        {
            await using var demoContext = ServiceProvider.GetService<DemoContext>();

            await Reset(demoContext: demoContext);
            await AddSamples(demoContext: demoContext);
            await DisplayUsers(demoContext: demoContext);
        }

        private static async Task Reset(DemoContext demoContext)
        {
            var users = await demoContext.Users.ToListAsync();
            demoContext.Users.RemoveRange(entities: users);
            await demoContext.SaveChangesAsync();
        }

        private static async Task DisplayUsers(DemoContext demoContext)
        {
            var users = await demoContext.Users.AsNoTracking().Take(count: 10).ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine(value: user);
            }
        }

        private static async Task AddSamples(DemoContext demoContext)
        {
            await demoContext.AddAsync(entity: new User(firstName: "John", lastName: "Doe", userName: "john.doe"));
            await demoContext.SaveChangesAsync();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DemoContext>(optionsAction: optionsBuilder => optionsBuilder.UseSqlServer(connectionString: Constants.ConnectionString));

            return services.BuildServiceProvider();
        }
    }
}