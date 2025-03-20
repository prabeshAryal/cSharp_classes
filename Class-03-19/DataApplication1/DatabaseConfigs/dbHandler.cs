using DataApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace DataApplication1.DatabaseConfigs
{
    public class AppDbContext : DbContext
    {
        public DbSet<Prabesh> Prabesh { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
