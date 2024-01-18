using HRSystemAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HRSystemAPI.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salarys { get; set;}
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
