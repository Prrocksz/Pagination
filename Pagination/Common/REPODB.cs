using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Common;

public class REPODB : DbContext
{
    public REPODB(DbContextOptions<REPODB> options) : base(options)
    {
        
    }
    
    public DbSet<Users> Users { get; set; }
}