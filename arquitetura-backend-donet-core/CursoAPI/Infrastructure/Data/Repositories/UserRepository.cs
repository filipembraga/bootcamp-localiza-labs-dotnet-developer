using CursoAPI.Business.Entities;
using CursoAPI.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPI.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<User> ObtainUserAsync(string login)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
