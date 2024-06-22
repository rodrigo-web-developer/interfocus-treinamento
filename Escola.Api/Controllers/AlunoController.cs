using InterfocusConsole.Dtos;
using InterfocusConsole.Entidades;
using InterfocusConsole.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Escola.Api.Controllers
{
    // /api/aluno
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService alunoService;

        public AlunoController(AlunoService alunoService)
        {
            this.alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult Listar(string pesquisa)
        {
            // ternário
            var alunos = string.IsNullOrEmpty(pesquisa) ?
                alunoService.Listar() :
                alunoService.Listar(pesquisa);
            return Ok(alunos);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetByCodigo(int codigo)
        {
            var aluno = alunoService.Retorna(codigo);
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest(ModelState);
            }

            var sucesso = alunoService.Criar(aluno,
                out List<ValidationResult> erros);
            if (sucesso)
            {
                return Ok(aluno);
            }
            else
            {
                return UnprocessableEntity(erros);
            }
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest(ModelState);
            }

            var sucesso = alunoService.Editar(aluno,
                out List<ValidationResult> erros);
            if (sucesso)
            {
                return Ok(aluno);
            }
            else if (erros.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return UnprocessableEntity(erros);
            }
        }
        /*
         CRUD - Create/Recover/Update/Delete
         */
        // DELETE /api/aluno/{codigo}
        [HttpDelete("{codigo}")] // concatena com o Route
        public IActionResult Remover(int codigo)
        {
            var aluno = alunoService.Excluir(codigo, out _);
            if (aluno == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(aluno);
            }
        }

        [HttpGet("[action]")]
        public IActionResult Inscricoes()
        {
            // ternário
            var insc = alunoService.ListarInscricoes();
            return Ok(insc);
        }

        [HttpPost("[action]")]
        public IActionResult Inscrever([FromBody] InscricaoDto dados)
        {
            var ins = new Inscricao
            {
                Aluno = new Aluno { Codigo = dados.AlunoCodigo },
                Curso = new Curso {  Id = dados.CursoId },
            };
            return Ok();
        }
    }
}
