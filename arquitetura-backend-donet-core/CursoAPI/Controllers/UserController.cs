using CursoAPI.Models;
using CursoAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CursoAPI.Filters;
using CursoAPI.Business.Entities;
using CursoAPI.Business.Repository;
using Microsoft.Extensions.Logging;
using CursoAPI.Configurations;
using System;
using System.Threading.Tasks;

namespace CursoAPI.Controllers
{
    [Route("api/v1/user")] //Rota
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public UserController(ILogger<UserController> logger,
            IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost] //Verbo POST nessa rota
        [Route("login")]
        [ValidationModelStateCustomized]
        public async Task<IActionResult> Login(LoginViewModelInput loginViewModelInput)
        {
            try
            {
                var user = await _userRepository.ObtainUserAsync(loginViewModelInput.Login);

                if (user == null)
                {
                    return BadRequest("Houve um erro ao tentar acessar.");
                }

                //if (usuario.Senha != loginViewModel.Senha.GerarSenhaCriptografada())
                //{
                //    return BadRequest("Houve um erro ao tentar acessar.");
                //}

                var userViewModelOutput = new UserViewModelOutput()
                {
                    Code = user.Code,
                    Login = loginViewModelInput.Login,
                    Email = user.Email
                };

                var token = _authenticationService.GenerateToken(userViewModelOutput);

                return Ok(new LoginViewModelOutput
                {
                    Token = token,
                    User = userViewModelOutput
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente.
        /// </summary>
        /// <param name="loginViewModelInput">View model do registro de login</param>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(RegisterViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidationModelStateCustomized]
        public async Task<IActionResult> Register(RegisterViewModelInput loginViewModelInput)
        {
            try
            {
                var user = await _userRepository.ObtainUserAsync(loginViewModelInput.Login);

                if (user != null)
                {
                    return BadRequest("Usuário já cadastrado");
                }

                user = new User
                {
                    Login = loginViewModelInput.Login,
                    Password = loginViewModelInput.Password,
                    Email = loginViewModelInput.Email
                };
                _userRepository.Add(user);
                _userRepository.Commit();

                return Created("", loginViewModelInput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
