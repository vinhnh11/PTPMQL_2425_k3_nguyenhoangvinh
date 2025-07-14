using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; } = null!;
       public DbSet<Daily> Dailys { get; set; }
        public DbSet<Hethongphanphoi> Hethongphanphois { get; set; }
    }
} 