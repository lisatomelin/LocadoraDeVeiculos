using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloCliente
{

    [TestClass]
    public class ServicoClienteTest
    {
        Mock<IRepositorioCliente> repositorioClienteMoq;
        Mock<IValidadorCliente> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCliente servicoCliente;

        Cliente cliente;

        public ServicoClienteTest()
        {
            repositorioClienteMoq = new Mock<IRepositorioCliente>();
            validadorMoq = new Mock<IValidadorCliente>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCliente = new ServicoCliente(repositorioClienteMoq.Object, validadorMoq.Object, contextoMoq.Object);

            cliente = new Cliente("JOANA", "s@c.c", "49 99999-9999", TipoClienteEnum.PessoaFisica, "123.456.789-00", "cnpj", "SC", "Floripa", "Centro", "Rua das Flores", 444);
        }


        [TestMethod]
        public void Deve_inserir_cliente_caso_ele_for_validp() //cenário 1
        {
            //action
            Result resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        }

        //[TestMethod]
        //public void Nao_deve_inserir_cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        //{
        //    //arrange
        //    string nomeCliente = "JOANA";
        //    repositorioClienteMoq.Setup(x => x.SelecionarPorNome(nomeCliente))
        //        .Returns(() =>
        //        {
        //            return new Cliente(nomeCliente);
        //        });

        //    //action
        //    var resultado = servicoCliente.Inserir(cliente);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCliente}' já está sendo utilizado");
        //    repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Cliente() //cenário 4
        {
            repositorioClienteMoq.Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cliente.");
        }

        [TestMethod]
        public void Deve_editar_cliente_caso_ele_for_valido() //cenário 1
        {
            //arrange 
            cliente = new Cliente("CUPOM1000");

            //action
            Result resultado = servicoCliente.Editar(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCliente.Editar(cliente);

            //assert        
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_cliente_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("JOANA"))
                 .Returns(() =>
                 {
                     return new Cliente(id, "JOANA");
                 });


            Cliente outroCliente = new Cliente(id, "JOANA");

            //action
            var resultado = servicoCliente.Editar(outroCliente);

            //assert 
            resultado.Should().BeSuccess();

            repositorioClienteMoq.Verify(x => x.Editar(outroCliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("JOANA"))
                 .Returns(() =>
                 {
                     return new Cliente("JOANA");
                 });

            Cliente novoCliente = new Cliente("JOANA");

            //action
            var resultado = servicoCliente.Editar(novoCliente);

            //assert
            resultado.Should().BeFailure();

            repositorioClienteMoq.Verify(x => x.Editar(novoCliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cliente() //cenário 5
        {
            repositorioClienteMoq.Setup(x => x.Editar(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCliente.Editar(cliente);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar cliente.");
        }

        [TestMethod]
        public void Deve_excluir_cliente_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var cliente = new Cliente("JOANA");

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoCliente.Excluir(cliente);

            //assert
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cliente_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            var cliente = new Cliente("JOANA");

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoCliente.Excluir(cliente);

            //assert
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cliente() //cenário 3
        {
            var cupom = new Cupom("JOANA");

            repositorioClienteMoq.Setup(x => x.Existe(It.IsAny<Cliente>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCliente.Excluir(cliente);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cliente");
        }

        //[TestMethod]
        //public void Nao_deve_excluir_cliente_caso_ele_esteja_relacionado_com_aluguel() //cenário 4
        //{
        //    var cliente = new Cliente("JOANA");

        //    repositorioClienteMoq.Setup(x => x.Existe(cliente))
        //       .Returns(() =>
        //       {
        //           return true;
        //       });

        //    repositorioClienteMoq.Setup(x => x.Excluir(It.IsAny<Cliente>()))
        //        .Throws(() =>
        //        {
        //            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBCliente");
        //        });

        //    //action
        //    Result resultado = servicoCliente.Excluir(cliente);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Este cliente está relacionada com um aluguel e não pode ser excluído");
        //}
    }
}
