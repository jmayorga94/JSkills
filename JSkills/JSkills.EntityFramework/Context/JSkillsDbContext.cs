using JSkills.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JSkills.EntityFramework.Context
{
    public class JSkillsDbContext : DbContext
    {
        public JSkillsDbContext(DbContextOptions options) : base(options)
        {

          
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
