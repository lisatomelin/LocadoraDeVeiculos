using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesUnitarios.Aplicacao.ModuloAutomovel
{
    [TestClass]
    public class ServicoAutomovelTest
    {
        Mock<IRepositorioAutomovel> repositorioAutomovel;
        Mock<IValidadorAutomovel> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoAutomovel servicoAutomovel;

        GrupoAutomoveis grupoAutomoveis;
        Automovel automovel;

        public ServicoAutomovelTest()
        {
            repositorioAutomovel = new Mock<IRepositorioAutomovel>();
            validadorMoq = new Mock<IValidadorAutomovel>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoAutomovel = new ServicoAutomovel(repositorioAutomovel.Object, validadorMoq.Object, contextoMoq.Object);

            grupoAutomoveis = new GrupoAutomoveis("GrupoA");
            automovel = new Automovel(1000, "AAA-1234", "Fiat", "azul", "4 portas", TipoCombustivelEnum.Gasolina, 100, 2010, grupoAutomoveis);
        }


        [TestMethod]
        public void Deve_inserir_automovel_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovel.Verify(x => x.Inserir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_automovel_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Placa", "Placa não está no formato correto"));
                    return resultado;
                });

            //action
            var resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            repositorioAutomovel.Verify(x => x.Inserir(automovel), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Automovel() //cenário 4
        {
            repositorioAutomovel.Setup(x => x.Inserir(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir automóvel.");
        }

        [TestMethod]
        public void Deve_editar_automovel_caso_ele_for_valido() //cenário 1
        {
            automovel.Ano = 2011;

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovel.Verify(x => x.Editar(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_automovel_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Placa", "Placa não está no formato correto"));
                    return resultado;
                });

            //action
            var resultado = servicoAutomovel.Editar(automovel);

            //assert        
            resultado.Should().BeFailure();
            repositorioAutomovel.Verify(x => x.Editar(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_automovel() //cenário 5
        {
            repositorioAutomovel.Setup(x => x.Editar(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar automóvel.");
        }

        [TestMethod]
        public void Deve_excluir_automovel_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var automovel = new Automovel();

            repositorioAutomovel.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoAutomovel.Excluir(automovel);

            //assert
            resultado.Should().BeSuccess();
            repositorioAutomovel.Verify(x => x.Excluir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_automovel_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            var automovel = new Automovel();

            repositorioAutomovel.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoAutomovel.Excluir(automovel);

            //assert
            resultado.Should().BeFailure();
            repositorioAutomovel.Verify(x => x.Excluir(automovel), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_automovel() //cenário 3
        {
            var automovel = new Automovel();

            repositorioAutomovel.Setup(x => x.Existe(It.IsAny<Automovel>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoAutomovel.Excluir(automovel);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Este automóvel não pode ser excluído");
        }

        ////[TestMethod]
        ////public void Nao_deve_excluir_cliente_caso_ele_esteja_relacionado_com_aluguel() //cenário 4
        ////{
        ////    var cliente = new Cliente("JOANA");

        ////    repositorioClienteMoq.Setup(x => x.Existe(cliente))
        ////       .Returns(() =>
        ////       {
        ////           return true;
        ////       });

        ////    repositorioClienteMoq.Setup(x => x.Excluir(It.IsAny<Cliente>()))
        ////        .Throws(() =>
        ////        {
        ////            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBCliente");
        ////        });

        ////    //action
        ////    Result resultado = servicoCliente.Excluir(cliente);

        ////    //assert 
        ////    resultado.Should().BeFailure();
        ////    resultado.Reasons[0].Message.Should().Be("Este cliente está relacionada com um aluguel e não pode ser excluído");
        ////}
    }
}

