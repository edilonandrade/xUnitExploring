using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {        
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200})]
        [InlineData(1000, new double[] { 800, 900, 1000, 990})]
        [InlineData(800, new double[] { 800})]

        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            
            //Assert
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - método sob teste
                () => leilao.TerminaPregao()
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Null(leilao.Ganhador.Cliente);
        }
    }
}
