using CursoAPI.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoAPI.Infrastructure.Data.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE"); //Definição do nome
            builder.HasKey(p => p.Code); //Chave primária
            builder.Property(p => p.Code).ValueGeneratedOnAdd();//Autoincremento
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User) //Chave estrangeira
                .WithMany().HasForeignKey(fk => fk.CodeUser);
        }
    }
}
