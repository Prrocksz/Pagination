using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Common;

public class REPODB : IdentityDbContext<IdentityUser>
{
    public REPODB(DbContextOptions<REPODB> options) : base(options)
    {
        
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Employees> Employees { get; set; }
}