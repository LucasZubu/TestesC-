using Etec.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Etec.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;

        public VeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execucaoo do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact/*(DisplayName = "Teste n�1")*/]
        //[Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComAceleracao10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact/*(DisplayName = "Teste n�2")*/]
        //[Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComFreio10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        //[Fact/*(DisplayName = "Teste n�3",*/( Skip = "Teste ainda n�o implementado")]
        //public void ValidaNomeProprietario()
        //{
        //    // Exemplo de utiliza��o do Skip
        //}

        [Fact]
        public void AlteraDadosVeiculoDeUmDeterminadoVeiculoComBaseNaPlaca()
        {
            //Arrange

            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Jos� Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Jos� Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; //Alterado
            veiculoAlterado.Modelo = "Opala";


            //Act
            var alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        [Fact]
        public void GerarFichadeInformacaodoProprioVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Fulano de tal";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ZXC-8888";

            //Act
            string dadosveiculo = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dadosveiculo);
        }

        [Fact]
         public void TestaNomeProprietarioComDoisCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";
            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaQuantidadeCaracteresPlacaVeiculo()
        {
            //Arrange
            string placa = "Ab";
            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa=placa
            );
        }
    }
}
