using HotelManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
    }
}
