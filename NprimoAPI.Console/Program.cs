using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace NprimoAPIConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Digite um número: ");
            string? input = Console.ReadLine(); // pode ser nulo

            int numero;
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out numero))
            {
                Console.WriteLine("Valor inválido! Definindo número = 45 por padrão.");
                numero = 45;
            }

            // Ajuste aqui a porta dependendo de onde você acessa a API
            // - Dentro do container: "http://localhost:8080"
            // - Externamente, se mapeado: "http://localhost:8084"
            string baseUrl = "http://localhost:8080";

            // Monta as URLs dos endpoints
            string urlDivisores = $"{baseUrl}/Divisores/divisores?numero={numero}";
            string urlDivisoresPrimos = $"{baseUrl}/Divisores/divisoresprimos?numero={numero}";

            try
            {
                using var client = new HttpClient();

                // Chama o endpoint de divisores
                var responseDivisores = await client.GetAsync(urlDivisores);
                responseDivisores.EnsureSuccessStatusCode(); // Lança exceção se não for 2xx

                // Lê o conteúdo da resposta como string e converte para lista de int
                string jsonDivisores = await responseDivisores.Content.ReadAsStringAsync();
                List<int>? listaDivisoresDeserializada = JsonSerializer.Deserialize<List<int>>(jsonDivisores);
                List<int> listaDivisores = listaDivisoresDeserializada ?? new List<int>();

                // Chama o endpoint de divisores primos
                var responsePrimos = await client.GetAsync(urlDivisoresPrimos);
                responsePrimos.EnsureSuccessStatusCode();

                string jsonPrimos = await responsePrimos.Content.ReadAsStringAsync();
                List<int>? listaPrimosDeserializada = JsonSerializer.Deserialize<List<int>>(jsonPrimos);
                List<int> listaPrimos = listaPrimosDeserializada ?? new List<int>();

                // Filtra somente divisores positivos para ficar igual ao exemplo do desafio
                List<int> divisoresPositivos = listaDivisores.FindAll(x => x > 0);
                List<int> primosPositivos = listaPrimos.FindAll(x => x > 0);

                // Exibe resultados
                Console.WriteLine($"\nNúmero de Entrada: {numero}");

                Console.Write("Números Divisores: ");
                Console.WriteLine(string.Join(" ", divisoresPositivos));

                Console.Write("Divisores Primos: ");
                Console.WriteLine(string.Join(" ", primosPositivos));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao consumir a API: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
