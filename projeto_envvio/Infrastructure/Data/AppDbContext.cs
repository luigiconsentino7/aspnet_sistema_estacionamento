using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
