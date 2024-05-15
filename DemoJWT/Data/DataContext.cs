using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DemoJWT.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoJWT.Data
{
    public sealed class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
