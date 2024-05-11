namespace InterfocusConsole.Entidades
{
    public class Inscricao
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

    }
}
