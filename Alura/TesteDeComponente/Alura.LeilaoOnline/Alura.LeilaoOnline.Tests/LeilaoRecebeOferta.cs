using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
            //Arranje - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);
            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            Assert.Equal(2, leilao.Lances.Count());
        }
    }
}
