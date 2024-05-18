namespace InterfocusConsole.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        // 0 - iniciante, 1 - intermediario, 2 - avançado, 3 - expert
        public NivelCurso Nivel { get; set; }
        public int Duracao { get; set; }

        void Metodo()
        {
            if (Nivel == NivelCurso.Iniciante) { }// faz alguma coisa
            else if (Nivel == NivelCurso.Intermediario) { } // faz outra coisa 
        }
    }

    public enum NivelCurso
    {
        Iniciante = 0,
        Intermediario = 1,
        Avancado = 2,
        Expert = 3
    }
}
