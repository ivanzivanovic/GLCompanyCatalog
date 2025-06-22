using GL.CompanyCatalog.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GL.CompanyCatalog.Identity
{
    public class GLIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GLIdentityDbContext()
        {

        }

        public GLIdentityDbContext(DbContextOptions<GLIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    }
}
