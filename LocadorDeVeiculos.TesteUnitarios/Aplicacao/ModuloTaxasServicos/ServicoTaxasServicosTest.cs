using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxasServicos;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Aplicacao.ModuloTaxasServicos
{
    [TestClass]
    public class ServicoTaxasServicosTest
    {
        Mock<IRepositorioTaxasServicos> repositorioTaxasServicosMoq;
        Mock<IValidadorTaxasServicos> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoTaxasServicos servicoTaxasServicos;

        TaxasServicos taxasServicos;

        public ServicoTaxasServicosTest()
        {
            repositorioTaxasServicosMoq = new Mock<IRepositorioTaxasServicos>();
            validadorMoq = new Mock<IValidadorTaxasServicos>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoTaxasServicos = new ServicoTaxasServicos(repositorioTaxasServicosMoq.Object, validadorMoq.Object, contextoMoq.Object);

            taxasServicos = new TaxasServicos("LIMPEZA", 100);
        }


        [TestMethod]
        public void Deve_inserir_taxasServicos_caso_ela_for_valida() 
        {
            //action
            Result resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Inserir(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_taxasServicos_caso_ela_seja_invalida() 
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxasServicos>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Inserir(taxasServicos), Times.Never());
        }

        //[TestMethod]
        //public void Nao_deve_inserir_taxasServicos_caso_o_nome_ja_esteja_cadastrado() 
        //{
        //    //arrange
        //    string nometaxasServicos = "Limpeza";
        //    repositorioTaxasServicosMoq.Setup(x => x.SelecionarPorNome(nometaxasServicos))
        //        .Returns(() =>
        //        {
        //            return new TaxasServicos(nometaxasServicos);
        //        });

        //    //action
        //    var resultado = servicoTaxasServicos.Inserir(taxasServicos);

        //   // assert
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be($"Este nome '{nometaxasServicos}' já está sendo utilizado");
        //    repositorioTaxasServicosMoq.Verify(x => x.Inserir(taxasServicos), Times.Never());
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_taxasServicos() 
        {
            repositorioTaxasServicosMoq.Setup(x => x.Inserir(It.IsAny<TaxasServicos>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir serviço.");
        }

        [TestMethod]
        public void Deve_editar_taxasServicos_caso_ela_for_valido() 
        {
            //arrange 
            taxasServicos = new TaxasServicos("CUPOM10");

            //action
            Result resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert 
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Editar(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_taxasServicos_caso_ele_seja_invalido() 
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxasServicos>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert        
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Editar(taxasServicos), Times.Never());
        }

        //[TestMethod]
        //public void Deve_editar_taxasServicos_com_o_mesmo_nome() 
        //{
        //    //arrange
        //    Guid id = Guid.NewGuid();

        //    repositorioTaxasServicosMoq.Setup(x => x.SelecionarPorNome("Limpeza"))
        //         .Returns(() =>
        //         {
        //             return new TaxasServicos("Limpeza");
        //         });


        //    TaxasServicos outroTaxasServicos = new TaxasServicos("Limpeza");

        //    //action
        //    var resultado = servicoTaxasServicos.Editar(outroTaxasServicos);

        //    //assert 
        //    resultado.Should().BeSuccess();

        //    repositorioTaxasServicosMoq.Verify(x => x.Editar(outroTaxasServicos), Times.Once());
        //}

        [TestMethod]
        public void Nao_deve_editar_taxasServicos_caso_o_nome_ja_esteja_cadastrado() 
        {
            //arrange
            repositorioTaxasServicosMoq.Setup(x => x.SelecionarPorNome("LIMPEZA"))
                 .Returns(() =>
                 {
                     return new TaxasServicos("LIMPEZA");
                 });

            TaxasServicos novoTaxasServicos = new TaxasServicos("LIMPEZA");

            //action
            var resultado = servicoTaxasServicos.Editar(novoTaxasServicos);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxasServicosMoq.Verify(x => x.Editar(novoTaxasServicos), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_taxasServicos() 
        {
            repositorioTaxasServicosMoq.Setup(x => x.Editar(It.IsAny<TaxasServicos>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar serviço.");
        }

        [TestMethod]
        public void Deve_excluir_taxasServicos_caso_ele_esteja_cadastrado() 
        {
            //arrange
            var taxasServicos = new TaxasServicos("Limpeza");

            repositorioTaxasServicosMoq.Setup(x => x.Existe(taxasServicos))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Excluir(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_taxasServicos_caso_ela_nao_esteja_cadastrada() 
        {
            //arrange
            var taxasServicos = new TaxasServicos("Limpeza");

            repositorioTaxasServicosMoq.Setup(x => x.Existe(taxasServicos))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Excluir(taxasServicos), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_taxasServicos() 
        {
            var taxasServicos = new TaxasServicos("Limpeza");

            repositorioTaxasServicosMoq.Setup(x => x.Existe(It.IsAny<TaxasServicos>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir serviço");
        }

    }
}
