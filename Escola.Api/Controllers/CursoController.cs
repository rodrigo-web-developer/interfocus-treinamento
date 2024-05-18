using InterfocusConsole.Entidades;
using InterfocusConsole.Services;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.ComponentModel.DataAnnotations;

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursoService service;

        public CursoController(CursoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetCursos()
        {
            var dados = service.Listar();
            return Ok(dados);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            var valido = service.Criar(curso, out List<ValidationResult> erros);
            return valido ? Ok(curso) : UnprocessableEntity(erros);
        }
    }
}
