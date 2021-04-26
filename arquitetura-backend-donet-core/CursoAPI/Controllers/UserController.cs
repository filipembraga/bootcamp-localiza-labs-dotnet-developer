using CursoAPI.Models;
using CursoAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CursoAPI.Filters;


namespace CursoAPI.Controllers
{
    [Route("api/v1/user")] //Rota
    [ApiController]
    public class UserController: ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost] //Verbo POST nessa rota
        [Route("login")]
        [ValidationModelStateCustomized]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {            
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("register")]
        [ValidationModelStateCustomized]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}
