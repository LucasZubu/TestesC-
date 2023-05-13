using Etec.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Etec.Estacionamento.Testes
{
    public class PatioTeste
    {
        private Veiculo veiculo = new Veiculo();
        public ITestOutputHelper Output { get; }
        public PatioTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do Construtor");

            veiculo.Proprietario = "André Silva";
            veiculo.Placa = "ASD-9999";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";

        }


        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arranje
            Patio estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ABC-0101";
            veiculo.Modelo = "Fusca";
            veiculo.Acelerar(10);
            veiculo.Frear(5);
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory (Skip = "Teste ainda não implementado!")]
        [InlineData("Fulano de Tal","ASD-1515","preto", "Gol")]
        [InlineData("Ciclano de Tal", "BJD-9999", "prata","Corsa")]
        [InlineData("Beltrano de Tal", "DHX-5555", "azul", "Ford Ranger")]
        [InlineData("Alano de Tal", "KGE-1111", "amarelo", "Camaro")]
        public void ValidaFaturamentoVariosVeiculos(string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo)
        {
            //Arranje
            Patio estacionamento = new Patio();

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Acelerar(10);
            veiculo.Frear(5);
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        

        public void Dispose()
        {
            Output.WriteLine("Execução do Cleanup");
        }
    }
}
