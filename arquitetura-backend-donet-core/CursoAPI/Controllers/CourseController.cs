using CursoAPI.Business.Entities;
using CursoAPI.Business.Repository;
using CursoAPI.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CursoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<UserController> _logger;

        public CourseController(ICourseRepository courseRepository, ILogger<UserController> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um curso", Type = typeof(CourseViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            try
            {
                Course course = new Course
                {
                    Name = courseViewModelInput.Name,
                    Description = courseViewModelInput.Description
                };

                var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                course.CodeUser = codigoUsuario;
                _courseRepository.Add(course);
                _courseRepository.Commit();

                var courseViewModelOutput = new CourseViewModelOutput
                {
                    Name = course.Name,
                    Description = course.Description,
                };

                return Created("", courseViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário.
        /// </summary>
        /// <returns>Retorna status ok e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CourseViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                var courses = _courseRepository.ObtainForUser(codeUser)
                    .Select(s => new CourseViewModelOutput()
                    {
                        Name = s.Name,
                        Description = s.Description
                    });

                return Ok(courses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}

   
