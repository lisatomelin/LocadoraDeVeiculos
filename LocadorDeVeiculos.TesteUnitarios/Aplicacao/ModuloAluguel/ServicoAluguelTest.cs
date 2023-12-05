    using FluentAssertions;
    using FluentResults;
    using FluentResults.Extensions.FluentAssertions;
    using FluentValidation.Results;   
    using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
    using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
    using LocadoraDeVeiculos.Dominio.ModuloAluguel;
    using LocadoraDeVeiculos.Dominio.ModuloParceiro;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ValidationResult = FluentValidation.Results.ValidationResult;

    namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloAluguel
    {
        //[TestClass]
        //public class ServicoAluguelTest
        //{
        //    Mock<IRepositorioAluguel> repositorioAluguelMoq;
        //    Mock<IValidadorAluguel> validadorMoq;

        //    private ServicoAluguel servicoAluguel;

        //    Aluguel aluguel;

        //    public ServicoAluguelTest()
        //    {
        //        repositorioAluguelMoq = new Mock<IRepositorioAluguel>();
        //        validadorMoq = new Mock<IValidadorAluguel>();
        //        servicoAluguel = new ServicoAluguel(repositorioAluguelMoq.Object, validadorMoq.Object);
        //        aluguel = new Aluguel("Aluguel01");
        //    }

        //    [TestMethod]
        //    public void Deve_inserir_aluguel_caso_ele_for_valido() //cenário 1
        //    {
        //        //arrange
        //        aluguel = new Aluguel("Aluguel01");

        //        //action
        //        Result resultado = servicoAluguel.Inserir(aluguel);

        //        //assert 
        //        resultado.Should().BeSuccess();
        //        repositorioAluguelMoq.Verify(x => x.Inserir(aluguel), Times.Once());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_inserir_Aluguel_caso_ele_seja_invalido() //cenário 2
        //    {
        //        //arrange
        //        validadorMoq.Setup(x => x.Validate(It.IsAny<Aluguel>()))
        //            .Returns(() =>
        //            {
        //                var resultado = new ValidationResult();
        //                resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
        //                return resultado;
        //            });

        //        //action
        //        var resultado = servicoAluguel.Inserir(aluguel);

        //        //assert             
        //        resultado.Should().BeFailure();
        //        repositorioAluguelMoq.Verify(x => x.Inserir(aluguel), Times.Never());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_inserir_aluguel_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        //    {
        //        //arrange
        //        string nomeAluguel = "Aluguel01";
        //        repositorioAluguelMoq.Setup(x => x.SelecionarPorNome(nomeAluguel))
        //            .Returns(() =>
        //            {
        //                return new Aluguel(nomeAluguel);
        //            });

        //        //action
        //        var resultado = servicoAluguel.Inserir(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeAluguel}' já está sendo utilizado");
        //        repositorioAluguelMoq.Verify(x => x.Inserir(aluguel), Times.Never());
        //    }

        //    [TestMethod]
        //    public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Aluguel() //cenário 4
        //    {
        //        repositorioAluguelMoq.Setup(x => x.Inserir(It.IsAny<Aluguel>()))
        //            .Throws(() =>
        //            {
        //                return new Exception();
        //            });

        //        //action
        //        Result resultado = servicoAluguel.Inserir(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Aluguel.");
        //    }


        //    [TestMethod]
        //    public void Deve_editar_Aluguel_caso_ela_for_valida() //cenário 1
        //    {
        //        //arrange           
        //        aluguel = new Aluguel("Aluguel02");

        //        //action
        //        Result resultado = servicoAluguel.Editar(aluguel);

        //        //assert 
        //        resultado.Should().BeSuccess();
        //        repositorioAluguelMoq.Verify(x => x.Editar(aluguel), Times.Once());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_editar_aluguel_caso_ela_seja_invalida() //cenário 2
        //    {
        //        //arrange
        //        validadorMoq.Setup(x => x.Validate(It.IsAny<Aluguel>()))
        //            .Returns(() =>
        //            {
        //                var resultado = new ValidationResult();
        //                resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
        //                return resultado;
        //            });

        //        //action
        //        var resultado = servicoAluguel.Editar(aluguel);

        //        //assert             
        //        resultado.Should().BeFailure();
        //        repositorioAluguelMoq.Verify(x => x.Editar(aluguel), Times.Never());
        //    }

        //    [TestMethod]
        //    public void Deve_editar_aluguel_com_o_mesmo_nome() //cenário 3
        //    {
        //        //arrange
        //        Guid id = Guid.NewGuid();

        //        repositorioAluguelMoq.Setup(x => x.SelecionarPorNome("Aluguel01"))
        //             .Returns(() =>
        //             {
        //                 return new Aluguel(id, "Aluguel01");
        //             });

        //        Aluguel outroAluguel = new Aluguel(id, "Aluguel01");

        //        //action
        //        var resultado = servicoAluguel.Editar(outroAluguel);

        //        //assert 
        //        resultado.Should().BeSuccess();

        //        repositorioAluguelMoq.Verify(x => x.Editar(outroAluguel), Times.Once());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_editar_aluguel_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        //    {
        //        //arrange
        //        repositorioAluguelMoq.Setup(x => x.SelecionarPorNome("Aluguel01"))
        //             .Returns(() =>
        //             {
        //                 return new Aluguel("Aluguel01");
        //             });

        //        Aluguel novoAluguel = new Aluguel("Aluguel01");

        //        //action
        //        var resultado = servicoAluguel.Editar(novoAluguel);

        //        //assert 
        //        resultado.Should().BeFailure();

        //        repositorioAluguelMoq.Verify(x => x.Editar(novoAluguel), Times.Never());
        //    }

        //    [TestMethod]
        //    public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_Aluguel() //cenário 5
        //    {
        //        repositorioAluguelMoq.Setup(x => x.Editar(It.IsAny<Aluguel>()))
        //            .Throws(() =>
        //            {
        //                return new Exception();
        //            });

        //        //action
        //        Result resultado = servicoAluguel.Editar(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Aluguel.");
        //    }


        //    [TestMethod]
        //    public void Deve_excluir_Aluguel_caso_ele_esteja_cadastrado() //cenário 1
        //    {
        //        //arrange
        //        var aluguel = new Aluguel ("Aluguel02");

        //        repositorioAluguelMoq.Setup(x => x.Existe(aluguel))
        //           .Returns(() =>
        //           {
        //               return true;
        //           });

        //        //action
        //        var resultado = servicoAluguel.Excluir(aluguel);

        //        //assert 
        //        resultado.Should().BeSuccess();
        //        repositorioAluguelMoq.Verify(x => x.Excluir(aluguel), Times.Once());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_excluir_aluguel_caso_ele_nao_esteja_cadastrado() //cenário 2
        //    {
        //        //arrange

        //        var aluguel = new Aluguel("Aluguel10");

        //        repositorioAluguelMoq.Setup(x => x.Existe(aluguel))
        //           .Returns(() =>
        //           {
        //               return false;
        //           });

        //        //action
        //        var resultado = servicoAluguel.Excluir(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        repositorioAluguelMoq.Verify(x => x.Excluir(aluguel), Times.Never());
        //    }

        //    [TestMethod]
        //    public void Nao_deve_excluir_aluguel_caso_ele_esteja_relacionado_com_cupom() //cenário 3
        //    {
        //        var aluguel = new Aluguel("Aluguel02");

        //        repositorioAluguelMoq.Setup(x => x.Existe(aluguel))
        //           .Returns(() =>
        //           {
        //               return true;
        //           });

        //        // como configurar um método para ele lançar uma sqlexception utilizando moq

        //        repositorioAluguelMoq.Setup(x => x.Excluir(It.IsAny<Aluguel>()))
        //            .Throws(() =>
        //            {
        //                return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCupom_TBAluguel");
        //            });

        //        //action
        //        Result resultado = servicoAluguel.Excluir(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        resultado.Reasons[0].Message.Should().Be("Este aluguel está relacionado com um cupom e não pode ser excluído");
        //    }

        //    [TestMethod]
        //    public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_aluguel() //cenário 4
        //    {
        //        var aluguel = new Aluguel("Aluguel02");

        //        repositorioAluguelMoq.Setup(x => x.Existe(aluguel))
        //          .Throws(() =>
        //          {
        //              return SqlExceptionCreator.NewSqlException();
        //          });

        //        //action
        //        Result resultado = servicoAluguel.Excluir(aluguel);

        //        //assert 
        //        resultado.Should().BeFailure();
        //        resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir aluguel");
        //    }
        //}
        //    }
    }
