using Jwt.Core.Entities;
using Jwt.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jwt.DataAccess.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}