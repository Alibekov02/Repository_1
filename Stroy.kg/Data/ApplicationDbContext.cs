using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stroy.kg.Models;

namespace Stroy.kg.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<CategoryM> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Product2> Product2 { get; set; }

        public DbSet<test> tests { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        
    }
}
