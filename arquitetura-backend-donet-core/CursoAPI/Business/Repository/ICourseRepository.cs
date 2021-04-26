using CursoAPI.Business.Entities;
using System.Collections.Generic;

namespace CursoAPI.Business.Repository
{
    public interface ICourseRepository
    {
        void Add(Course course);
        void Commit();

        IList<Course> ObtainForUser(int codeUser);
    }
}
