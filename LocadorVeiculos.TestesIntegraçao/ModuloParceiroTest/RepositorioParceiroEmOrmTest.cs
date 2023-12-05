using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloParceiro
{
    [TestClass]
    public class RepositorioParceiroEmOrmTest : TestesIntegracaoBase
    {

        [TestMethod]
        public void Deve_inserir_parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Build();

            //action
            repositorioParceiro.Inserir(parceiro);

            contextoPersistencia.GravarDados();

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }


        [TestMethod]
        public void Deve_editar_parceiro()
        {
            //arrange
            var parceiroId = Builder<Parceiro>.CreateNew().Persist().Id;

            var parceiro = repositorioParceiro.SelecionarPorId(parceiroId);
            parceiro.Nome = "Parceiro01";

            //action
            repositorioParceiro.Editar(parceiro);

            contextoPersistencia.GravarDados();

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id)
                .Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_excluir_parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            repositorioParceiro.Excluir(parceiro);

            contextoPersistencia.GravarDados();

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
        }


        [TestMethod]
        public void Deve_selecionar_todos_parceiros()
        {
            //arrange
            var parceiro01 = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Parceiro01").Persist();
            var parceiro02 = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Parceiro02").Persist();

            //action
            var disciplinas = repositorioParceiro.SelecionarTodos();

            //assert
            disciplinas.Should().ContainInOrder(parceiro01, parceiro02);
            disciplinas.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_parceiro_por_nome()
        {
            //arrange
            var parceiro02 = Builder<Parceiro>.CreateNew().Persist();

            //action
            var disciplinasEncontrada = repositorioParceiro.SelecionarPorNome(parceiro02.Nome);

            //assert
            disciplinasEncontrada.Should().Be(parceiro02);
        }

        [TestMethod]
        public void Deve_selecionar_parceiro_por_id()
        {
            //arrange
            var parceiro02 = Builder<Parceiro>.CreateNew().Persist();

            //action
            var disciplinasEncontrada = repositorioParceiro.SelecionarPorId(parceiro02.Id);

            //assert            
            disciplinasEncontrada.Should().Be(parceiro02);
        }
    }
}

