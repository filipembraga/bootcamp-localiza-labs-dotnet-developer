using CursoAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CursoAPI.Configurations
{
    public class DbFactoryDbContext: IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            /*var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();*/

            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=COURSE;user=sa;password=12345");
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);
            return context;
        }
    }
}
