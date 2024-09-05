using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

bool digitarNovamente;
decimal precoInicial, precoPorHora;

Console.Write("Seja bem vindo ao sistema de estacionamento!");
Console.WriteLine();

do
{
    Console.Write("Digite o preço inicial: ");
    digitarNovamente = !decimal.TryParse(Console.ReadLine(), out precoInicial);
    if (digitarNovamente){
        Console.WriteLine("Digite um preço inicial valido.");
    }                                
} while (digitarNovamente);

Console.WriteLine();

do
{
    Console.Write("Agora digite o preço por hora: ");
    digitarNovamente = !decimal.TryParse(Console.ReadLine(), out precoPorHora);
    if (digitarNovamente){
        Console.WriteLine("Digite um preço por hora valido.");
    }                                
} while (digitarNovamente);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.Write("Opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine();
    Console.Write("Pressione Enter para continuar...");
    Console.ReadLine();
}

Console.WriteLine("Estacionamento fechado!");