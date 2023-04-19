using Microsoft.EntityFrameworkCore;
using SignalR_Products_CRUD.Models;

namespace SignalR_Products_CRUD.Data
{
    public class AppSettingsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppSettingsDbContext(DbContextOptions<AppSettingsDbContext> options) : base(options) { }
    }
}
