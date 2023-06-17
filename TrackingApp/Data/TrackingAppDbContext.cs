using Microsoft.EntityFrameworkCore;
using TrackingApp.Models.Domain;

namespace TrackingApp.Data
{
    public class TrackingAppDbContext : DbContext
    {
        public TrackingAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
    }
}
