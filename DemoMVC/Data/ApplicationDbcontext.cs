using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DemoMVC.Models.Entities;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Daily> Dailys { get; set; }
        public DbSet<Hethongphanphoi> Hethongphanphois { get; set; }
        public DbSet<Employee> Employee { get; set; } 
        public DbSet<MemberUnit> MemberUnits { get; set; }
    }
} 