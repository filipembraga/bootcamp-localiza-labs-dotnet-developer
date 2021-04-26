using CursoAPI.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoAPI.Infrastructure.Data.Mapping
{
    public class UserMapping: IEntityTypeConfiguration<User>{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER"); //Definição do nome da tabela
            builder.HasKey(p => p.Code); //Chave primária
            builder.Property(p => p.Code).ValueGeneratedOnAdd(); //Valor gerado e adicionado
            builder.Property(p => p.Login);
            builder.Property(p => p.Password);
            builder.Property(p => p.Email);
        } 
            
    }
}
