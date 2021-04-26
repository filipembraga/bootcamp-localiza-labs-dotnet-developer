using CursoAPI.Business.Entities;
using CursoAPI.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CursoAPI.Infrastructure.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Constroi baseado nas classes em Mapping:
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
