using CursoAPI.Business.Entities;
using System.Threading.Tasks;

namespace CursoAPI.Business.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Commit();
        Task<User> ObtainUserAsync(string login);
    }
}
