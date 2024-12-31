using System.Collections.Generic;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void TestarDivisores()
    {
        var divisores = Program.EncontrarDivisores(45);
        Assert.Equal(new List<int> { -45, -15, -9, -5, -3, -1, 1, 3, 5, 9, 15, 45 }, divisores);
    }

    [Fact]
    public void TestarPrimos()
    {
        var primos = Program.EncontrarPrimos(new List<int> { 1, 3, 5, 9, 15, 45 });
        // 1 não é primo, então sobram 3 e 5
        Assert.Equal(new List<int> { 3, 5 }, primos);
    }

    [Fact]
    public void TestarDivisoresPara1()
    {
        var divisores = Program.EncontrarDivisores(1);
        // Esperado -1 e 1
        Assert.Equal(new List<int> { -1, 1 }, divisores);
    }

    [Fact]
    public void TestarDivisoresPrimosPara1()
    {
        var primos = Program.EncontrarPrimos(new List<int> { -1, 1 });
        // 1 e -1 não são primos
        Assert.Empty(primos);
    }

    [Fact]
    public void TestarDivisoresPara2()
    {
        var divisores = Program.EncontrarDivisores(2);
        // Esperado: -2, -1, 1, 2
        Assert.Equal(new List<int> { -2, -1, 1, 2 }, divisores);
    }

    [Fact]
    public void TestarDivisoresPrimosPara2()
    {
        var primos = Program.EncontrarPrimos(new List<int> { -2, -1, 1, 2 });
        // -2 e 2 são primos (valor absoluto = 2)
        Assert.Equal(new List<int> { -2, 2 }, primos);
    }

    [Fact]
    public void TestarDivisoresPara0()
    {
        var divisores = Program.EncontrarDivisores(0);
        // Por definição do código, retornamos vazio
        Assert.Empty(divisores);
    }

    [Fact]
    public void TestarDivisoresPrimosParaNegativo()
    {
        var divisores = Program.EncontrarDivisores(-5);
        // Divisores esperados: -5, -1, 1, 5
        Assert.Equal(new List<int> { -5, -1, 1, 5 }, divisores);

        var primos = Program.EncontrarPrimos(divisores);
        // -5 e 5 são considerados primos (abs(5) == 5)
        Assert.Equal(new List<int> { -5, 5 }, primos);
    }
}
