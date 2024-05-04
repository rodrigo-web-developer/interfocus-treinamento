using System.ComponentModel.DataAnnotations;

namespace InterfocusConsole
{
    public class AlunoService
    {
        private static int Contador = 1000;
        private static List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno { Nome = "Rodrigo teste", Codigo = 1, DataNascimento = new DateTime(2000,1,1), Email = "teste@email.com" },
            new Aluno { Nome = "Fulano de tal", Codigo = 2, DataNascimento = new DateTime(2000,2,1), Email = "fulano@email.com" },
            new Aluno { Nome = "Jobiscleyson Souza", Codigo = 3, DataNascimento = new DateTime(2000,1,5), Email = "job@email.com" },
            new Aluno { Nome = "Maria josé", Codigo = 4, DataNascimento = new DateTime(1998,1,1), Email = "maria@email.com" },
        };

        
        public static bool Validacao(Aluno aluno,
            out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(aluno,
                new ValidationContext(aluno),
                erros,
                true
            );

            var diaMinimo = DateTime.Today.AddYears(-18);
            if (aluno.DataNascimento > diaMinimo)
            {
                erros.Add(new ValidationResult(
                        "O aluno deve ser maior de 18 anos",
                        new[] { "DataNascimento" })
                    );
                valido = false;
            }

            return valido;
        }

        public static bool CriarAluno(Aluno aluno,
            out List<ValidationResult> erros)
        {
            aluno.Codigo = Contador++;
            var valido = Validacao(aluno, out erros);
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
            return valido;
        }

        public static bool EditarAluno(Aluno novoAluno,
            out List<ValidationResult> erros)
        {
            var alunoExistente = Alunos.
                FirstOrDefault(x => x.Codigo == novoAluno.Codigo);

            erros = new List<ValidationResult>();

            if (alunoExistente == null)
            {
                return false;
            }

            var valido = Validacao(novoAluno, out erros);
            if (valido)
            {
                alunoExistente.Nome = novoAluno.Nome;
                alunoExistente.Email = novoAluno.Email;
                alunoExistente.DataNascimento = novoAluno.DataNascimento;
            }
            return valido;
        }

        public static List<Aluno> Listar()
        {
            return Alunos;
        }
        public static List<Aluno> Listar(string buscaAluno,
            int skip = 0, int pageSize = 0)
        {
            var consulta = Alunos.Where(a =>
                    a.Codigo.ToString() == buscaAluno ||
                    a.Nome.Contains(buscaAluno,
                            StringComparison.OrdinalIgnoreCase) ||
                    a.Email.Contains(buscaAluno)
                )
                .OrderBy(x => x.DataNascimento)
                .AsEnumerable();
            if (skip > 0)
            {
                consulta = consulta.Skip(skip);
            }
            if (pageSize > 0)
            {
                consulta = consulta.Take(pageSize);
            }

            return consulta.ToList();
        }

        public static Aluno Remover(int codigo)
        {
            var aluno = Alunos
                        .Where(x => x.Codigo == codigo)
                        .FirstOrDefault();
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
