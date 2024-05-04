using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfocusConsole
{
    public class AlunoService
    {
        private static List<Aluno> Alunos = new List<Aluno>();
        public static void CriarAluno(Aluno aluno)
        {
            var erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(aluno,
                new ValidationContext(aluno),
                erros,
                true
                );
            if (valido)
            {
                Alunos.Add(aluno);
            }
            else
            {
                foreach (var erro in erros)
                {
                    Console.WriteLine("{0}: {1}",
                        erro.MemberNames.First(),
                        erro.ErrorMessage
                    );
                }
            }
        }
        public static List<Aluno> Listar()
        {
            return Alunos;
        }
        public static List<Aluno> Listar(string buscaAluno)
        {
            return Alunos.Where(a =>
                    a.Codigo.ToString() == buscaAluno ||
                    a.Nome.Contains(buscaAluno,
                            StringComparison.OrdinalIgnoreCase) ||
                    a.Email.Contains(buscaAluno)
                )
                .OrderBy(x => x.DataNascimento)
                .ToList();
        }

        public static Aluno Remover(int codigo)
        {
            var aluno = Alunos
                        .Where(x => x.Codigo == codigo)
                        .First();
            Alunos.Remove(aluno);
            // Overflow()
            // Overflow() ->
            // Overflow() ->
            // Overflow() ->
            // Main ->
            return aluno;
        }
    }
}
