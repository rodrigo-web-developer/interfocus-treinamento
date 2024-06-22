using System.ComponentModel.DataAnnotations;

namespace InterfocusConsole.Entidades
{
    public class Aluno
    {
        public Aluno()
        {
            Nome = "Inicializado";
        }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 10)]
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int Codigo { get; set; }

        private string email;
        [Required]
        public string Email
        {
            get => email;
            set => email = value?.ToLower();
        }

        public string PhotoUrl { get; set; }

        //public IList<Inscricao> Inscricoes { get; set; }


        public virtual void PrintDados()
        {
            Console.WriteLine(
                "{0} {1} {2} {3:dd/MM/yyyy}",
                Codigo, Nome, Email, DataNascimento
             );
        }
    }
    public class Bolsista : Aluno
    {
        public double Desconto { get; set; }
        public override void PrintDados()
        {
            Console.WriteLine(
                "{0} ({3}%) {1} {2} {4:dd/MM/yyyy}",
                Codigo, Nome, Email, Desconto, DataNascimento
             );
        }

    }
}
