using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Digite um número: ");
        string? input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Nenhum número foi digitado.");
            return;
        }

        if (!int.TryParse(input, out int numero))
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
            return;
        }

        var divisores = EncontrarDivisores(numero);
        var primos = EncontrarPrimos(divisores);

        Console.WriteLine($"Número de Entrada: {numero}");
        Console.WriteLine($"Números divisores: {string.Join(" ", divisores)}");
        Console.WriteLine($"Divisores Primos: {string.Join(" ", primos)}");
    }

    /// <summary>
    /// Retorna todos os divisores (positivos e negativos) do número informado.
    /// </summary>
    public static List<int> EncontrarDivisores(int numero)
    {
        // Se for zero, não há divisores definidos (ou, teoricamente, infinitos).
        // Aqui optamos por retornar lista vazia para simplificar.
        if (numero == 0)
            return new List<int>();

        var divisores = new HashSet<int>();

        // Percorre de 1 até o valor absoluto do número.
        for (int i = 1; i <= Math.Abs(numero); i++)
        {
            if (Math.Abs(numero) % i == 0)
            {
                // Adiciona divisor positivo
                divisores.Add(i);

                // Adiciona divisor negativo correspondente
                divisores.Add(-i);

                // Se i for diferente de (numero / i), também adiciona este
                int quociente = Math.Abs(numero) / i;
                divisores.Add(quociente);
                divisores.Add(-quociente);
            }
        }

        // Ajuste especial para 1 (para garantir -1 na lista, caso queira explicitamente).
        // Porém, acima já faz esse tratamento. Se quiser garantir, podemos forçar:
        if (numero == 1 && !divisores.Contains(-1))
        {
            divisores.Add(-1);
        }

        // Para ordenar de forma crescente (incluindo negativos) e retornar como List<int>
        var sortedDivisores = divisores.ToList();
        sortedDivisores.Sort();
        return sortedDivisores;
    }

    /// <summary>
    /// Retorna apenas os números primos (positivos ou negativos) de uma lista de inteiros.
    /// </summary>
    public static List<int> EncontrarPrimos(List<int> numeros)
    {
        var primos = new List<int>();
        foreach (var num in numeros)
        {
            if (EhPrimo(num))
            {
                primos.Add(num);
            }
        }
        primos.Sort();
        return primos;
    }

    /// <summary>
    /// Verifica se o número é primo. 
    /// Neste desafio, assumimos que números negativos podem ser considerados primos 
    /// se seu valor absoluto for primo. Exemplo: -2, -3, -5.
    /// </summary>
    public static bool EhPrimo(int numero)
    {
        // Vamos trabalhar com o valor absoluto
        int absNumero = Math.Abs(numero);

        // Menor que 2 não é primo
        if (absNumero < 2)
            return false;

        // 2 é primo
        if (absNumero == 2)
            return true;

        // Se for par e maior que 2, não é primo
        if (absNumero % 2 == 0)
            return false;

        // Teste de divisibilidade até a raiz quadrada
        int limite = (int)Math.Sqrt(absNumero);
        for (int i = 3; i <= limite; i += 2)
        {
            if (absNumero % i == 0)
                return false;
        }

        return true;
    }
}
