using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        ///  Solicita uma placa de veiculo, valida e adiciona na lista de veiculos estacionados
        /// </summary>
        public void AdicionarVeiculo()
        {
            string placa;

            do
            {
                Console.WriteLine();
                Console.Write("Digite a placa do veículo para estacionar ou 'SAIR' para voltar: ");
                placa = Console.ReadLine()?.ToUpper();

                if (placa.Contains("SAIR")){
                    return;
                }

            } while (!ValidarPlaca(placa));

            veiculos.Add(placa);
            Console.WriteLine($"O Veículo {placa} foi estacionado.");
        }

        /// <summary>
        /// Solicita uma placa de veiculo, as horas estacionado, calcula o valor total a pagar e o remove da lista de veiculos estacionados 
        /// </summary>
        public void RemoverVeiculo()
        {
            if(!veiculos.Any())
            {
                Console.WriteLine("Estacionamento vazio. Não há veículos para serem removidos.");
                return;
            }

            Console.WriteLine();
            Console.Write("Digite a placa do veículo a ser removido: ");
            string placa = Console.ReadLine()?.ToUpper();
            int horasEstacionado = 0;
            bool digitarNovamente;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");   
                    digitarNovamente = !int.TryParse(Console.ReadLine(), out horasEstacionado);
                    if (digitarNovamente){
                        Console.WriteLine("Digite uma quantidade de horas válida.");
                    }                                
                } while (digitarNovamente);

                decimal valorTotal = precoInicial + (precoPorHora * horasEstacionado); 

                veiculos.Remove(placa); 

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        /// <summary>
        /// Lista a quantidade total de veiculos estacionados e suas respectivas placas
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine();
                Console.WriteLine($"Existem {veiculos.Count} veículos estacionados.\nSão estes:");
                veiculos.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Estacionamento vazio. Não há veículos estacionados.");
            }
        }

        /// <summary>
        /// Valida se a placa informada é válida e se já existe na lista de veiculos estacionados
        /// </summary>
        /// <param name="placa">Placa de veiculo</param>
        /// <returns></returns>
        private bool ValidarPlaca(string placa){

            bool placaValida = Regex.IsMatch(placa, "[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            
            if (!placaValida || veiculos.Contains(placa)){
                Console.WriteLine("Placa inválida ou veículo já estacionado.");
                return false;
            }
            
            return placaValida;
        }
    }
}
