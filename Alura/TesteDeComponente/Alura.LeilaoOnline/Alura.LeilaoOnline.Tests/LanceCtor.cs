using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            var excecaoObtida = Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
                );

            var mensagemEsperada = "Valor do lance deve ser maior que zero.";
            Assert.Equal(mensagemEsperada, excecaoObtida.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void LancaArgumentExceptionDadoValorMenorOuIgualaZero(int valorLance)
        {
            //Arranje
            
            //Assert
            var excecaoObtida = Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(null, valorLance)
                );

            var mensagemEsperada = "Valor do lance deve ser maior que zero.";
            Assert.Equal(mensagemEsperada, excecaoObtida.Message);
        }
    }
}
