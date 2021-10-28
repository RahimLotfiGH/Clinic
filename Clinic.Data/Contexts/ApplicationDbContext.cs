using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
