using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Aplicacao.ModuloGrupoAutomoveis
{
    [TestClass]
    public class ServicoGrupoAutomoveisTeste
    {
        Mock<IRepositorioGrupoAutomoveis> repositorioGrupoAutomoveisMoq;
        Mock<IValidadorGrupoAutomoveis> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoGrupoAutomoveis servicoGrupoAutomoveis;

        GrupoAutomoveis grupoAutomoveis;

        public ServicoGrupoAutomoveisTeste()
        {
            repositorioGrupoAutomoveisMoq = new Mock<IRepositorioGrupoAutomoveis>();
            validadorMoq = new Mock<IValidadorGrupoAutomoveis>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoGrupoAutomoveis = new ServicoGrupoAutomoveis(repositorioGrupoAutomoveisMoq.Object, validadorMoq.Object, contextoMoq.Object);
            grupoAutomoveis = new GrupoAutomoveis("GrupoDeAutomoveis01");
        }

        [TestMethod]
        public void Deve_inserir_GrupoAutomoveis_caso_seja_valido() //cenário 1
        {
            //arrange
            grupoAutomoveis = new GrupoAutomoveis("GrupoDeAutomoveis02");

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_GrupoAutomoveis_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomoveis>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_GrupoAutomoveis_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeGrupoAutomoveis = "GrupoDeAutomoveis01";
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome(nomeGrupoAutomoveis))
                .Returns(() =>
                {
                    return new GrupoAutomoveis(nomeGrupoAutomoveis);
                });

            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeGrupoAutomoveis}' já está sendo utilizado");
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_grupoAutomoveis() //cenário 4
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Inserir(It.IsAny<GrupoAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Grupo de Automoveis.");
        }

        [TestMethod]
        public void Deve_editar_GrupoAutomoveis_caso_for_valido() //cenário 1
        {
            //arrange           
            grupoAutomoveis = new GrupoAutomoveis("Grupo02");

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_GrupoAutomoveis_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomoveis>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_GrupoAutomoveis_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("GrupoDeAutomoveis01"))
                 .Returns(() =>
                 {
                     return new GrupoAutomoveis(id, "GrupoDeAutomoveis01");
                 });

            GrupoAutomoveis outraGrupoAutomoveis = new GrupoAutomoveis(id, "GrupoDeAutomoveis01");

            //action
            var resultado = servicoGrupoAutomoveis.Editar(outraGrupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(outraGrupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_GrupoAutomoveis_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            Guid id = Guid.NewGuid();
            //arrange
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("GrupoDeAutomoveis01"))
                 .Returns(() =>
                 {
                     return new GrupoAutomoveis(id, "GrupoDeAutomoveis01");
                 });

            GrupoAutomoveis novaDisciplina = new GrupoAutomoveis("GrupoDeAutomoveis01");

            //action
            var resultado = servicoGrupoAutomoveis.Editar(novaDisciplina);

            //assert 
            resultado.Should().BeFailure();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(novaDisciplina), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_GrupoAutomoveis() //cenário 5
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Editar(It.IsAny<GrupoAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Grupo de Automoveis.");
        }

        [TestMethod]
        public void Deve_excluir_GrupoAutomoveis_caso_esteja_cadastrado() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange
            var disciplina = new GrupoAutomoveis(id, "GrupoAutomoveis01");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(disciplina);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(disciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_GrupoAutomoveis_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            Guid id = Guid.NewGuid();
            //arrange
            var grupoAutomoveis = new GrupoAutomoveis(id, "Matemática");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupoAutomoveis))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(grupoAutomoveis), Times.Never());
        }

        //[TestMethod]
        //public void Nao_deve_excluir_grupoAutomoveis_caso_a_esteja_relacionada_com_aluguel() //cenário 3
        //{
        //    Guid id = new Guid();

        //    var grupoAutomoveis = new GrupoAutomoveis(id, "Grupo01");

        //    repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupoAutomoveis))
        //       .Returns(() =>
        //       {
        //           return true;
        //       });

        //    // como configurar um método para ele lançar uma sqlexception utilizando moq

        //    repositorioGrupoAutomoveisMoq.Setup(x => x.Excluir(It.IsAny<GrupoAutomoveis>()))
        //        .Throws(() =>
        //        {
        //            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBGrupoAutomoveis");
        //        });

        //    //action
        //    Result resultado = servicoGrupoAutomoveis.Excluir(grupoAutomoveis);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Este grupo de automoveis está relacionada com um aluguel e não pode ser excluído");
        //}

        //[TestMethod]
        //public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_grupoAutomoveis() //cenário 4
        //{
        //    Guid id = Guid.NewGuid();

        //    var disciplina = new GrupoAutomoveis(id, "Grupo01");

        //    repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupoAutomoveis))
        //      .Throws(() =>
        //      {
        //          return SqlExceptionCreator.NewSqlException();
        //      });

        //    //action
        //    Result resultado = servicoGrupoAutomoveis.Excluir(grupoAutomoveis);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir Grupo de Automoveis");
        //}
    }
}
