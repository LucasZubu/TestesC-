using Etec.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Etec.Estacionamento.Testes
{
    public class PesquisaVeiculoTeste
    {

        private Veiculo veiculo = new Veiculo();
        public ITestOutputHelper Output { get; }
        public PesquisaVeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do Construtor");

            veiculo.Proprietario = "André Silva";
            veiculo.Placa = "ASD-9999";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";

        }

        [Theory]
        [InlineData("Fulano de Tal","ASD-1515","preto", "Gol")]
        [InlineData("Ciclano de Tal", "BJD-9999", "prata","Corsa")]
        [InlineData("Beltrano de Tal", "DHX-5555", "azul", "Ford Ranger")]
        [InlineData("Alano de Tal", "KGE-1111", "amarelo", "Camaro")]        
        public void DeveRetornarVeiculoComPlacaExistente(string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo)
        {
            Patio estacionamento = new Patio();
            // Arrange
            string placa = "BJD-9999";

            // Act
            var encontrado = veiculo.PesquisaVeiculo(placa);

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Assert
            Assert.IsNotNull(encontrado);
            Assert.AreEqual("Ford Ranger", encontrado.Marca);
            Assert.AreEqual("Uno", encontrado.Modelo);
        }

        public void DeveRetornarNullComPlacaInexistente()
        {
            // Arrange
            string placa = "GHI9012";

            // Act
            var encontrado = veiculo.PesquisaVeiculo(placa);

            // Assert
            Assert.IsNull(encontrado);
        }
  
    }
}