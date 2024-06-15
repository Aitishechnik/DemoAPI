using DemoAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data
{
    public sealed class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public DbSet<AutoEntity> Cars { get; set; } = null!;
        public DbSet<GarageEntity> Garages { get; set; } = null!;
        public DbSet<UserEntity> UsersCustom { get; set; } = null!;
        public DbSet<UserLogEntity> UserLogs { get; set; } = null!;
        public DbSet<ItemEntity> Items { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
