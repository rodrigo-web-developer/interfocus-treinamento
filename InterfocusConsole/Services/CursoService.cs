using InterfocusConsole.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfocusConsole.Services
{
    public class CursoService
    {
        private readonly ISessionFactory session;

        public CursoService(ISessionFactory session)
        {
            this.session = session;
        }

        public static bool Validacao(Curso aluno,
            out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(aluno,
                new ValidationContext(aluno),
                erros,
                true
            );

            return valido;
        }

        public bool Criar(Curso curso, out List<ValidationResult> erros)
        {
            if (Validacao(curso, out erros))
            {
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                sessao.Save(curso);
                transaction.Commit();
                return true;
            }
            return false;
        }

        public bool Editar(Curso curso, out List<ValidationResult> erros)
        {
            if (Validacao(curso, out erros))
            {
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                sessao.Merge(curso);
                transaction.Commit();
                return true;
            }
            return false;
        }

        public bool Excluir(int id, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            var curso = sessao.Query<Curso>()
                .Where(c => c.Id == id)
                .FirstOrDefault();
            if (curso == null)
            {
                erros.Add(new ValidationResult("Registro não encontrado",
                    new[] { "id" }));
                return false;
            }

            sessao.Delete(curso);
            transaction.Commit();
            return true;
        }

        public virtual List<Curso> Listar()
        {
            using var sessao = session.OpenSession();
            var cursos = sessao.Query<Curso>().ToList();
            return cursos;
        }

        public virtual List<Curso> Listar(string busca)
        {
            using var sessao = session.OpenSession();
            var cursos = sessao.Query<Curso>()
                .Where(c => c.Nome.Contains(busca) ||
                            c.Descricao.Contains(busca))
                .OrderBy(c => c.Id)
                .Take(4)
                .ToList();
            return cursos;
        }
    }


    public class CursoService2 : CursoService
    {
        public CursoService2(ISessionFactory session) : base(session)
        {
        }

        public override List<Curso> Listar()
        {
            return base.Listar();
        }
    }
}
