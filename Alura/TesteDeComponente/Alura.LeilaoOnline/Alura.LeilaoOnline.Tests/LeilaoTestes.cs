using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(beltrano, 1400);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(1400, leilao.Ganhador.Valor);
            Assert.Equal(beltrano, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);            
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(1000, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(1000, leilao.Ganhador.Valor);


        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(800, leilao.Ganhador.Valor);

        }
    }
}
