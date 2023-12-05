using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloParceiro
{
    [TestClass]
    public class ServicoParceiroTest
    {
        Mock<IRepositorioParceiro> repositorioParceiroMoq;
        Mock<IValidadorParceiro> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoParceiro servicoParceiro;

        Parceiro parceiro;

        public ServicoParceiroTest()
        {
            repositorioParceiroMoq = new Mock<IRepositorioParceiro>();
            validadorMoq = new Mock<IValidadorParceiro>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoParceiro = new ServicoParceiro(repositorioParceiroMoq.Object, validadorMoq.Object, contextoMoq.Object);
            parceiro = new Parceiro("Parceiro01");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ele_for_valido() //cenário 1
        {
            //arrange
            parceiro = new Parceiro("Parceiro01");

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoParceiro.Inserir(parceiro);

            //assert             
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeParceiro = "Parceiro01";
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                .Returns(() =>
                {
                    return new Parceiro(nomeParceiro);
                });

            //action
            var resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeParceiro}' já está sendo utilizado");
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_parceiro() //cenário 4
        {
            repositorioParceiroMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir parceiro.");
        }


        [TestMethod]
        public void Deve_editar_parceiro_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            parceiro = new Parceiro("Parceiro02");

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoParceiro.Editar(parceiro);

            //assert             
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_parceiro_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("Parceiro01"))
                 .Returns(() =>
                 {
                     return new Parceiro(id, "Parceiro01");
                 });

            Parceiro outroParceiro = new Parceiro(id, "Parceiro01");

            //action
            var resultado = servicoParceiro.Editar(outroParceiro);

            //assert 
            resultado.Should().BeSuccess();

            repositorioParceiroMoq.Verify(x => x.Editar(outroParceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("Parceiro01"))
                 .Returns(() =>
                 {
                     return new Parceiro("Parceiro01");
                 });

            Parceiro novoParceiro = new Parceiro("Parceiro01");

            //action
            var resultado = servicoParceiro.Editar(novoParceiro);

            //assert 
            resultado.Should().BeFailure();

            repositorioParceiroMoq.Verify(x => x.Editar(novoParceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_parceiro() //cenário 5
        {
            repositorioParceiroMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar parceiro.");
        }


        [TestMethod]
        public void Deve_excluir_parceiro_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var parceiro = new Parceiro("Parceiro02");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_parceiro_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange

            var parceiro = new Parceiro("Matemática");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_excluir_parceiro_caso_ele_esteja_relacionado_com_cupom() //cenário 3
        {
            var parceiro = new Parceiro("Parceiro02");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return true;
               });

            // como configurar um método para ele lançar uma sqlexception utilizando moq

            repositorioParceiroMoq.Setup(x => x.Excluir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCupom_TBParceiro");
                });

            //action
            Result resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Este parceiro está relacionado com um cupom e não pode ser excluído");
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_parceiro() //cenário 4
        {
            var parceiro = new Parceiro("Parceiro02");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir parceiro");
        }
    }
}
