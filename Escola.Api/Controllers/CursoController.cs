using InterfocusConsole.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ISessionFactory session;

        public CursoController(ISessionFactory session)
        {
            this.session = session;
        }

        [HttpGet]
        public IActionResult GetCursos()
        {
            using var dados = session.OpenSession();
            var cursos = dados.Query<Curso>().ToList();
            return Ok(cursos);
        }
    }
}
