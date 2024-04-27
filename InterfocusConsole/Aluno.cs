using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfocusConsole
{
    public class Aluno
    {
        public Aluno()
        {
            Nome = "Inicializado";
        }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Codigo { get; set; }

        private string email;
        public string Email
        {
            get => email;
            set => email = value?.ToLower();
        }

        public virtual void PrintDados()
        {
            Console.WriteLine(
                "{0} {1} {2}",
                Codigo, Nome, Email
             );
        }
    }
    public class Bolsista : Aluno
    {
        public double Desconto { get; set; }
        public override void PrintDados()
        {
            Console.WriteLine(
                "{0} ({3}%) {1} {2}",
                Codigo, Nome, Email, Desconto
             );
        }

    }
}
