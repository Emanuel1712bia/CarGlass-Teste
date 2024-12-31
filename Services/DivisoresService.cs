using System;
using System.Collections.Generic;
using System.Linq;

namespace NprimoAPI.Services
{
    public class DivisoresService
    {
        public List<int> EncontrarDivisores(int numero)
        {
            if (numero == 0)
                return new List<int>();

            var divisores = new HashSet<int>();

            for (int i = 1; i <= Math.Abs(numero); i++)
            {
                if (Math.Abs(numero) % i == 0)
                {
                    divisores.Add(i);
                    divisores.Add(-i);

                    int quociente = Math.Abs(numero) / i;
                    divisores.Add(quociente);
                    divisores.Add(-quociente);
                }
            }

            // Ajuste para 1 quando o número de entrada for 1
            if (numero == 1 && !divisores.Contains(-1))
            {
                divisores.Add(-1);
            }

            var sortedDivisores = divisores.ToList();
            sortedDivisores.Sort();
            return sortedDivisores;
        }

        public List<int> EncontrarPrimos(List<int> numeros)
        {
            var primos = new List<int>();
            foreach (var num in numeros)
            {
                if (EhPrimo(num))
                    primos.Add(num);
            }
            primos.Sort();
            return primos;
        }

        private bool EhPrimo(int numero)
        {
            int absNumero = Math.Abs(numero);

            // Considerar 1 como primo para este desafio
            if (absNumero == 1)
                return true;

            if (absNumero < 2)
                return false;

            if (absNumero == 2)
                return true;

            if (absNumero % 2 == 0)
                return false;

            int limite = (int)Math.Sqrt(absNumero);
            for (int i = 3; i <= limite; i += 2)
            {
                if (absNumero % i == 0)
                    return false;
            }

            return true;
        }
    }
}
