using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NprimoAPI.Tests
{
    public class DivisoresServiceTests
    {
        [Fact]
        public void TestarDivisoresPrimosParaNegativo_Menos5()
        {
            var resultado = ObterDivisoresPrimos(-5);
            Assert.Equal(new List<int> { -5, 5 }, resultado.OrderBy(x => x).ToList());
        }

        [Fact]
        public void TestarDivisoresPrimosPara2_DeveRetornarMenos2E2()
        {
            var resultado = ObterDivisoresPrimos(2);
            Assert.Equal(new List<int> { -2, 2 }, resultado.OrderBy(x => x).ToList());
        }

        [Fact]
        public void TestarPrimos_DeveRetornarPrimosDe45()
        {
            var resultado = ObterPrimos(45);
            Assert.Equal(new List<int> { 3, 5 }, resultado.Where(x => x > 0).OrderBy(x => x).ToList());
        }

        [Fact]
        public void TestarDivisoresPrimosPara1_NaoExistePrimos()
        {
            var resultado = ObterDivisoresPrimos(1);
            Assert.Empty(resultado);
        }

        // Método auxiliar para obter divisores primos
        private List<int> ObterDivisoresPrimos(int numero)
        {
            if (numero == 1 || numero == -1) return new List<int>();

            var divisores = ObterDivisores(numero);
            return divisores.Where(ehPrimo).OrderBy(x => x).ToList();
        }

        // Método para obter todos os divisores de um número
        private List<int> ObterDivisores(int numero)
        {
            var divisores = new List<int>();
            int limite = System.Math.Abs(numero);

            for (int i = 1; i <= limite; i++)
            {
                if (numero % i == 0)
                {
                    divisores.Add(i);
                    divisores.Add(-i);
                }
            }

            return divisores.Distinct().ToList();
        }

        // Método para verificar se um número é primo
        private bool ehPrimo(int numero)
        {
            numero = System.Math.Abs(numero);
            if (numero < 2) return false;

            for (int i = 2; i <= System.Math.Sqrt(numero); i++)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }

        // Método para obter os números primos de um valor específico
        private List<int> ObterPrimos(int numero)
        {
            return ObterDivisores(numero).Where(ehPrimo).Where(x => x > 0).OrderBy(x => x).ToList();
        }
    }
}
