using DisciplinaryCase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisciplinaryCase.Mapping
{
    public class DisciplineMapping : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable ("Disciplines");
            builder.HasKey(x => x.id);
             
        }
    }
}
