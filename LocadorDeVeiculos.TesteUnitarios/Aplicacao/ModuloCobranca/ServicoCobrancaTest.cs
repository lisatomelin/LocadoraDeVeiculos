using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;

namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloCobranca
{
    [TestClass]
    public class ServicoCobrancaTest
    {
        Mock<IRepositorioGrupoAutomoveis> repositorioGrupoAutomoveis;
        Mock<IRepositorioCobranca> repositorioCobrancaMoq;
        Mock<IValidadorCobranca> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCobranca servicoCobranca;

        GrupoAutomoveis grupoAutomoveis;
        Cobranca cobranca;

        public ServicoCobrancaTest()
        {
            repositorioCobrancaMoq = new Mock<IRepositorioCobranca>();
            validadorMoq = new Mock<IValidadorCobranca>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCobranca = new ServicoCobranca(repositorioCobrancaMoq.Object, validadorMoq.Object, contextoMoq.Object);

            grupoAutomoveis = new GrupoAutomoveis("Picape");
            cobranca = new Cobranca(grupoAutomoveis, TipoPlanoEnum.PlanoDiario, 20, 0);
        }

        [TestMethod]
        public void Deve_inserir_cobranca_caso_ele_for_valida() //cenário 1
        {
            //action
            Result resultado = servicoCobranca.Inserir(cobranca);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Inserir(cobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cobranca_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCobranca.Inserir(cobranca);

            //assert 
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Inserir(cobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Cobranca() //cenário 4
        {
            repositorioCobrancaMoq.Setup(x => x.Inserir(It.IsAny<Cobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCobranca.Inserir(cobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir plano de cobrança.");
        }

        [TestMethod]
        public void Deve_editar_cobranca_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoCobranca.Editar(cobranca);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Editar(cobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cobranca_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Preço Diária", "Preço Diária não pode ser menor que 0."));
                    return resultado;
                });

            //action
            var resultado = servicoCobranca.Editar(cobranca);

            //assert        
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Editar(cobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cobranca() //cenário 5
        {
            repositorioCobrancaMoq.Setup(x => x.Editar(It.IsAny<Cobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCobranca.Editar(cobranca);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar plano de cobrança.");
        }

        [TestMethod]
        public void Deve_excluir_cobranca_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            repositorioCobrancaMoq.Setup(x => x.Existe(cobranca))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoCobranca.Excluir(cobranca);

            //assert
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Excluir(cobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cobranca_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            repositorioCobrancaMoq.Setup(x => x.Existe(cobranca))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoCobranca.Excluir(cobranca);

            //assert
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Excluir(cobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cobranca() //cenário 3
        {
            repositorioCobrancaMoq.Setup(x => x.Existe(It.IsAny<Cobranca>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCobranca.Excluir(cobranca);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir plano de cobrança");
        }

        [TestMethod]
        public void Nao_deve_excluir_cobranca_caso_ele_esteja_relacionado_com_aluguel() //cenário 4
        {
            repositorioCobrancaMoq.Setup(x => x.Existe(cobranca))
               .Returns(() =>
               {
                   return true;
               });

            repositorioCobrancaMoq.Setup(x => x.Excluir(It.IsAny<Cobranca>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBCobranca");
                });

            //action
            Result resultado = servicoCobranca.Excluir(cobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Este plano de cobrança está relacionado com um aluguel e não pode ser excluído");
        }
    }
}

