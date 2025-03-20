using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using DataApplication1.DatabaseConfigs;

namespace DataApplication1
{
    public static class DatabaseMigrationExtension
    {
        public static async Task MigrateDatabaseAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();

                // Check if database exists and create it if it doesn't
                if (!(await context.Database.CanConnectAsync()))
                {
                    await context.Database.EnsureCreatedAsync();
                    Console.WriteLine("Database created successfully");
                }
                else
                {
                    Console.WriteLine("Database already exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                throw;
            }
        }
    }
}