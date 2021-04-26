using CursoAPI.Models.Users;


namespace CursoAPI.Configurations
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput userViewModelOutput);
    }
}
