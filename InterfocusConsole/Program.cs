// See https://aka.ms/new-console-template for more information

// import 
using InterfocusConsole;
using InterfocusConsole.Entidades;
using InterfocusConsole.Services;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

//Console.WriteLine(x);
int x = 10;
var z = x;
z += 1;

Console.WriteLine("X:{0} Z:{1}", x, z);


var y = "texto";
bool b = true;
double d = 1.75;

if (d > 0 && d < 1)
{

}
else if (d < 1.5)
{

}
else
{
    Console.WriteLine("D está acima de 1.5");
}
// object/collection INITIALIZER
var lista = new List<string> {
    "Item 1",
    "Item 2"
};

var lista2 = lista;

lista2.Add("Item 3");

Console.WriteLine($"Lista 1: {lista.Count} itens");
Console.WriteLine($"Lista 2: {lista2.Count} itens");

var soma = x + z;
var maiorQueDez = soma > 10;
var impar = soma % 2 == 1;

var combinacao = maiorQueDez && impar; // maiorQueDez and impar

while (z < 15)
{
    Console.WriteLine("Z: {0}", z);
    z++;
}

var v = 1;
do
{
    //var texto = Console.ReadLine();
    //v = int.Parse(texto);
} while (v % 2 == 0);

Console.WriteLine("Digitou: " + v);

for (var i = 0; i < 10; i++)
{
    Console.WriteLine("iteracao {1:D03}: {0:C}", i, i + 1);
}

var data = new DateTime(2024, 4, 20);

Console.WriteLine(data);
Console.WriteLine("{0:dd/MM/yyyy}", data);

Console.WriteLine(data.Day);
Console.WriteLine(data.DayOfYear);
Console.WriteLine(data.DayOfWeek);
Console.WriteLine(data.Year);

var agora = DateTime.Now;
var hoje = DateTime.Today;
var amanha = hoje.AddDays(1);
var ontem = hoje.AddDays(-1);

var meioDia = hoje.AddHours(12);
Console.WriteLine(agora);
Console.WriteLine(hoje);
Console.WriteLine(amanha);
Console.WriteLine(ontem);
Console.WriteLine(meioDia);

// def isPar(numero):

//var t = int.Parse(Console.ReadLine());

//Metodos.IsPar(t);


var objeto = new Metodos();
//var objeto2 = new Metodos();
//var objeto3 = new Metodos();

//objeto.PrintarLista(lista);

//var a1 = new Aluno
//{
//    Nome = "Rodrigo",
//    DataNascimento = new DateTime(2000, 1, 1),
//    Codigo = 1001
//};
//// chamando set
//a1.Email = "Rodrigo@GMail.com";
////chamando o get
//Console.WriteLine("Email: {0}", a1.Email);

//var a2 = new Aluno();

//Console.WriteLine("ALUNO 1: {0}", a1.Nome);
//Console.WriteLine("ALUNO 2: {0}", a2.Nome);

//Aluno a3 = null;

//var b1 = new Bolsista
//{
//    Nome = "Bolsista 1",
//    Codigo = 1002,
//    Desconto = 0.5
//};

//a3 = new Bolsista();

//Console.WriteLine("ALUNO 3: {0}", a3?.Nome);

//Console.ReadKey();

string Input(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine();
}

int codigo = 1000;

while (true)
{
    Console.Clear();
    Console.WriteLine("Digite a opção:");
    Console.WriteLine("1 - Verificar número par");
    Console.WriteLine("2 - Adicionar item lista");
    Console.WriteLine("3 - Printar lista");
    Console.WriteLine("4 - Buscar na lista");
    Console.WriteLine("5 - Cadastrar Aluno");
    Console.WriteLine("6 - Listar alunos");
    Console.WriteLine("7 - Buscar alunos");
    Console.WriteLine("8 - Excluir aluno");
    Console.WriteLine("0 - Sair");
    var inputValido =
        int.TryParse(Console.ReadLine(),
        out int opcao);

    if (!inputValido)
    {
        Console.WriteLine("Erro: digite um número valido");
        Console.ReadKey();
        continue;
    }

    // match(opcao):
    if (opcao == 0)
    {
        break;
    }

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite um numero: ");
            var numero = int.Parse(Console.ReadLine());
            Metodos.IsPar(numero);
            break;
        case 2:
            Console.WriteLine("Digite o item: ");
            var item = Console.ReadLine();
            lista.Add(item);
            break;
        case 3:
            objeto.PrintarLista(lista);
            break;
        case 4:
            Console.WriteLine("Digite a busca: ");
            var busca = Console.ReadLine();
            // lambda function
            var helloWorld = () =>
            Console.WriteLine("Hello World!");
            helloWorld();
            // LINQ - Language Integrated Query
            // LINQ Metodico

            var resultado = lista
                .Where(x => x.Contains(busca,
                                StringComparison.OrdinalIgnoreCase)
                )
                .OrderByDescending(x => x)
                .Select(x => x.ToUpper())
                .ToList();

            var sintatico = from a in lista
                            where a.Contains(busca)
                            orderby a descending
                            select a;
            objeto.PrintarLista(resultado);
            break;
        case 5:
            var resposta = Input("Aluno bolsista?");
            if (resposta != "S")
            {
                var novoAluno = new Aluno
                {
                    Nome = Input("Digite o nome do aluno: "),
                    Email = Input("Digite o email do aluno: "),
                    DataNascimento =
                    DateTime.Parse(
                        Input("Digite a data de nascimento: ")
                    ),
                    Codigo = codigo++
                };
                AlunoService.CriarAluno(novoAluno, out _);
            }
            else
            {
                var novoAluno = new Bolsista
                {
                    Nome = Input("Digite o nome do aluno: "),
                    Email = Input("Digite o email do aluno: "),
                    DataNascimento =
                    DateTime.Parse(
                        Input("Digite a data de nascimento: ")
                    ),
                    Desconto = double.Parse(
                        Input("Porcentagem de desconto: ")
                    ),
                    Codigo = codigo++
                };
                AlunoService.CriarAluno(novoAluno, out _);
            }
            break;
        case 6:
            foreach (var aluno in AlunoService.ListarTodos())
            {
                aluno.PrintDados();
            }
            break;
        case 7:
            var buscaAluno = Input("Digite a busca: ");
            foreach (var aluno in AlunoService.ListarPage(buscaAluno))
            {
                aluno.PrintDados();
            }
            break;
        case 8:
            try
            {
                var codigoAluno = int.Parse(Input(
                        "Digite o codigo do aluno:"));
                var removido = AlunoService.Remover(codigoAluno);
                if (removido != null)
                {
                    removido.PrintDados();
                }
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("Stack overflow");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Digite um codigo valido");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Console.ReadKey();
    if (opcao == 1)
    {

    }
    else if (opcao == 2) { }
    else if (opcao == 3) { }
    else
    {

    }

}
