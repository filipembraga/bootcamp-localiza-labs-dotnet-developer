using CursoAPI.Business.Entities;
using CursoAPI.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CursoAPI.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void Add(Course course)
        {
            _context.Course.Add(course);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Course> ObtainForUser(int codeUser)
        {
            return _context.Course.Include(i => i.User).Where(w => w.CodeUser == codeUser).ToList();
        }
    }
}
