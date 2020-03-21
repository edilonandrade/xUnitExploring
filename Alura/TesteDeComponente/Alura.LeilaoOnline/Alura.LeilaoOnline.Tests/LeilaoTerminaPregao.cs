﻿using Alura.LeilaoOnline.Core;
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
           
            foreach(var valor in ofertas)            
                leilao.RecebeLance(fulano, valor);            

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
           

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(0, leilao.Ganhador.Valor);
        }
    }
}
