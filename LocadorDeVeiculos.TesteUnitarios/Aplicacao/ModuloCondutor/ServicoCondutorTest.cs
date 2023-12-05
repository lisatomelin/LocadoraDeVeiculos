using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloCondutor
{
    [TestClass]
    public class ServicoCondutorTest
    {
        Mock<IRepositorioCondutor> repositorioCondutorMoq;
        Mock<IValidadorCondutor> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCondutor servicoCondutor;
        Condutor condutor;
        Cliente cliente;

        public ServicoCondutorTest()
        {
            repositorioCondutorMoq = new Mock<IRepositorioCondutor>();
            validadorMoq = new Mock<IValidadorCondutor>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCondutor = new ServicoCondutor(repositorioCondutorMoq.Object, validadorMoq.Object, contextoMoq.Object);

            cliente = new Cliente("Valeria" );

            condutor = new Condutor(cliente, true, "Mariana", "condutor@ex.com", "49 99999-9999", "025.154.563-58", "25445455", DateTime.Now);
        }


        [TestMethod]
        public void Deve_inserir_condutor_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCondutor = "Mariana";
            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(nomeCondutor);
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{condutor.Nome}' já está sendo utilizado");
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Condutor() //cenário 4
        {
            repositorioCondutorMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Condutor.");
        }

        [TestMethod]
        public void Deve_editar_condutor_caso_ele_for_valido() //cenário 1
        {
            //arrange 
            condutor = new Condutor(cliente, true, "Joana", "joana@exemplo.com", "49 88888-8888", "025.154.563-58", "98765432", DateTime.Now);

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Editar(condutor);

            //assert        
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_condutor_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            string nomeCondutor = "Mariana";
            Guid id = Guid.NewGuid();

            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(id, nomeCondutor);
                });

            Condutor outroCondutor = new Condutor(id, nomeCondutor);

            //action
            var resultado = servicoCondutor.Editar(outroCondutor);

            //assert 
            resultado.Should().BeSuccess();

            repositorioCondutorMoq.Verify(x => x.Editar(outroCondutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            string nomeCondutor = "Mariana";

            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(nomeCondutor);
                });

            Condutor novoCondutor = new Condutor(nomeCondutor);

            //action
            var resultado = servicoCondutor.Editar(novoCondutor);

            //assert
            resultado.Should().BeFailure();

            repositorioCondutorMoq.Verify(x => x.Editar(novoCondutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_condutor() //cenário 5
        {
            repositorioCondutorMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Condutor.");
        }

        [TestMethod]
        public void Deve_excluir_condutor_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var condutor = new Condutor(cliente, true, "Miguel", "miguel@exemplo.com", "47 55555-5555", "123.456.789-01", "98765432", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
                .Returns(() =>
                {
                    return true;
                });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_condutor_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            var condutor = new Condutor(cliente, true, "Miguel", "miguel@exemplo.com", "47 55555-5555", "123.456.789-01", "98765432", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
                .Returns(() =>
                {
                    return false;
                });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_condutor() //cenário 3
        {
            var condutor = new Condutor(cliente, true, "Miguel", "miguel@exemplo.com", "47 55555-5555", "123.456.789-01", "98765432", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException();
                });

            //action
            Result resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir Condutor");
        }

        //[TestMethod]
        //public void Nao_deve_excluir_condutor_caso_ele_esteja_relacionado_com_aluguel() //cenário 4
        //{
        //    var condutor = new Condutor(cliente, true, "Miguel", "miguel@exemplo.com", "47 55555-5555", "123.456.789-01", "98765432", DateTime.Now);

        //    repositorioCondutorMoq.Setup(x => x.Existe(condutor))
        //        .Returns(() =>
        //        {
        //            return true;
        //        });

        //    repositorioCondutorMoq.Setup(x => x.Excluir(It.IsAny<Condutor>()))
        //        .Throws(() =>
        //        {
        //            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBCondutor");
        //        });

        //    //action
        //    Result resultado = servicoCondutor.Excluir(condutor);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Este condutor está relacionada com um aluguel e não pode ser excluído");
        //}

    }
}
