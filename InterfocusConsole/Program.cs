// See https://aka.ms/new-console-template for more information

// import 
using InterfocusConsole;
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

var v = 0;
do
{
    var texto = Console.ReadLine();
    v = int.Parse(texto);
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

var t = int.Parse(Console.ReadLine());

//Metodos.IsPar(t);

var objeto = new Metodos();
//var objeto2 = new Metodos();
//var objeto3 = new Metodos();

//objeto.PrintarLista(lista);

while (true)
{
    Console.Clear();
    Console.WriteLine("Digite a opção:");
    Console.WriteLine("1 - Verificar número par");
    Console.WriteLine("2 - Adicionar item lista");
    Console.WriteLine("3 - Printar lista");
    Console.WriteLine("4 - Buscar na lista");
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
