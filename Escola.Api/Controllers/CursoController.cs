using InterfocusConsole.Entidades;
using InterfocusConsole.Services;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetCursos(string busca = null)
        {
            var dados = busca == null ?
                            service.Listar() :
                            service.Listar(busca);
            return Ok(dados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dados = service.Retorna(id);
            return Ok(dados);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            var valido = service.Criar(curso, out List<ValidationResult> erros);
            return valido ? Ok(curso) : UnprocessableEntity(erros);
        }


        [HttpPut]
        public IActionResult Put([FromBody] Curso curso)
        {
            var valido = service.Editar(curso, out List<ValidationResult> erros);
            return valido ? Ok(curso) : UnprocessableEntity(erros);
        }

        [HttpDelete("{cursoId}")]
        public IActionResult Delete(int cursoId)
        {
            var valido = service.Excluir(cursoId, out List<ValidationResult> erros);
            return valido ? Ok(valido) : UnprocessableEntity(erros);
        }

        [HttpGet("[action]")]
        public IActionResult Relatorio()
        {
            var cursos = service.ConsultaAlunosPorNivel();
            return Ok(cursos);
        }
    }
}
