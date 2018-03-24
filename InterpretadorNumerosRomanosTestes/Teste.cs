using NUnit.Framework;
using FluentAssertions;
using InterpretadorNumerosRomanos;

namespace InterpretadorNumerosRomanosTestes
{
    [TestFixture]
    public class Teste
    {
        [Test]
        public void deve_entender_o_numero_I_como_1()
        {
            var resultado = new Interpretador().Converter("I");
            resultado.Should().Be(1);
        }

        [Test]
        public void deve_entender_o_numero_V_como_5()
        {
            var resultado = new Interpretador().Converter("V");
            resultado.Should().Be(5);
        }

        [Test]
        public void deve_entender_o_numero_X_como_10()
        {
            var resultado = new Interpretador().Converter("X");
            resultado.Should().Be(10);
        }

        [TestCase("XX", 20)]
        [TestCase("II", 2)]
        public void deve_entender_dois_numeros_romanos_iguais(string entrada, int resultadoEsperado)
        {
            var resultado = new Interpretador().Converter(entrada);
            resultado.Should().Be(resultadoEsperado);
        }

        [TestCase("XXII", 22)]
        [TestCase("XV", 15)]
        [TestCase("XXV", 25)]
        [TestCase("LIII", 53)]        
        public void deve_entender_numeros_romanos_diferentes(string entrada, int resultadoEsperado)
        {
            var resultado = new Interpretador().Converter(entrada);
            resultado.Should().Be(resultadoEsperado);
        }

        [TestCase("IX", 9)]
        [TestCase("XLIV", 44)]
        [TestCase("LIX", 59)]
        [TestCase("CDXLIV", 444)]
        
        public void deve_entender_numeros_romanos_menores_a_esquerda(string entrada, int resultadoEsperado)
        {
            var resultado = new Interpretador().Converter(entrada);
            resultado.Should().Be(resultadoEsperado);
        }
    }
}
