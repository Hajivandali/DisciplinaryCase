using DisciplinaryCase.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase
{
    public class DisciplineContext:DbContext
    {
        public DisciplineContext(DbContextOptions<DisciplineContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DisciplineMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
