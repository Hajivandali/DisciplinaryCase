using DisciplinaryCase.Models;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase
{
    public class DisciplineContext : DbContext
    {
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<DisciplineCategory> DisciplineCategories { get; set; }

        public DisciplineContext(DbContextOptions<DisciplineContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
