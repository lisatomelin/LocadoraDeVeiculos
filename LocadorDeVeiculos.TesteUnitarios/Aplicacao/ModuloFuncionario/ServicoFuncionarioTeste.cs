using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.TestesUnitarios.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoFuncionarioTeste
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;
        Mock<IValidadorFuncionario> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoFuncionario servicoFuncionario;

        Funcionario funcionario;

        public ServicoFuncionarioTeste()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            validadorMoq = new Mock<IValidadorFuncionario>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, validadorMoq.Object, contextoMoq.Object);
            funcionario = new Funcionario(new Guid(),"Gabriel", DateTime.Now, 2000);
        }

        [TestMethod]
        public void Deve_funcionario_caso_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            Guid id = Guid.NewGuid();
            //arrange
            string nomeFuncionario = "Gabriel";
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome(nomeFuncionario))
                .Returns(() =>
                {
                    return new Funcionario(id, nomeFuncionario);
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeFuncionario}' já está sendo utilizado");
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_funcionario() //cenário 4
        {
            repositorioFuncionarioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir funcionario.");
        }

        [TestMethod]
        public void Deve_editar_funcionario_caso_seja_valido() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange           
            funcionario = new Funcionario(id, "Artes");

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_ela_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Editar(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome() //cenário 3
        {
            Guid id = Guid.NewGuid();
            //arrange
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("Gabriel"))
                 .Returns(() =>
                 {
                     return new Funcionario(id, "Gabriel");
                 });

            Funcionario outraFuncionario = new Funcionario(id, "Gabriel");

            //action
            var resultado = servicoFuncionario.Editar(outraFuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Editar(outraFuncionario), Times.Once());
        }

        //[TestMethod]
        //public void Nao_deve_editar_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        //{
        //    Guid id = Guid.NewGuid();
        //    //arrange
        //    repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("Gabriel"))
        //         .Returns(() =>
        //         {
        //             return new Funcionario(id, "Gabriel");
        //         });

        //    Funcionario novoFuncionario = new Funcionario(id, "Gabriel");

        //    //action
        //    var resultado = servicoFuncionario.Editar(novoFuncionario);

        //    //assert 
        //    resultado.Should().BeFailure();

        //    repositorioFuncionarioMoq.Verify(x => x.Editar(novoFuncionario), Times.Never());
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_funcionario() //cenário 5
        {
            repositorioFuncionarioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar funcionario.");
        }

        [TestMethod]
        public void Deve_excluir_funcionario_caso_ela_esteja_cadastrada() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange
            var funcionario = new Funcionario(id, "Gabriel");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            Guid id = Guid.NewGuid();
            //arrange

            var funcionario = new Funcionario(id, "Gabriel");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Never());
        }

        //[TestMethod]
        //public void Nao_deve_excluir_funcionario_caso_ela_esteja_relacionada_com_aluguel() //cenário 3
        //{
        //    Guid id = Guid.NewGuid();

        //    var disciplina = new Funcionario(id, "Gabriel");

        //    repositorioFuncionarioMoq.Setup(x => x.Existe(disciplina))
        //       .Returns(() =>
        //       {
        //           return true;
        //       });

        //    // como configurar um método para ele lançar uma sqlexception utilizando moq

        //    repositorioFuncionarioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>()))
        //        .Throws(() =>
        //        {
        //            return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBFuncionario");
        //        });

        //    //action
        //    Result resultado = servicoFuncionario.Excluir(disciplina);

        //    //assert 
        //    resultado.Should().BeFailure();
        //    resultado.Reasons[0].Message.Should().Be("Este fucnionario está relacionado com um aluguel e não pode ser excluído");
        //}

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_disciplina() //cenário 4
        {
            Guid id = Guid.NewGuid();

            var funcionario = new Funcionario(id, "Gabriel");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir funcionario");
        }
    }
}
