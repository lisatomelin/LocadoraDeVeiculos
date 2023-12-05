using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloAutomovel
{
    [TestClass]
    public class RepositorioAutomovelEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_automovel()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();

            var automovel = Builder<Automovel>.CreateNew().Build();
            automovel.GrupoDoAutomovel = grupoAutomoveis;

            repositorioAutomovel.Inserir(automovel);

            contextoPersistencia.GravarDados();

            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_Editar_automovel()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var automovel = Builder<Automovel>.CreateNew()
                .With(c => c.GrupoDoAutomovel = grupoAutomoveis)
            .Persist();

            automovel.Marca = "Fiat";

            repositorioAutomovel.Editar(automovel);

            contextoPersistencia.GravarDados();

            repositorioAutomovel.SelecionarPorId(automovel.Id)
                .Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_excluir_automovel()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var automovel = Builder<Automovel>.CreateNew()
                .With(c => c.GrupoDoAutomovel = grupoAutomoveis)
            .Persist();

            repositorioAutomovel.Excluir(automovel);

            contextoPersistencia.GravarDados();

            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_automoveis()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var automovel1 = Builder<Automovel>.CreateNew()
                .With(c => c.GrupoDoAutomovel = grupoAutomoveis)
            .Persist();

            var automovel2 = Builder<Automovel>.CreateNew()
                .With(c => c.GrupoDoAutomovel = grupoAutomoveis)
            .Persist();

            var automoveis = repositorioAutomovel.SelecionarTodos();

            automoveis.Should().ContainInOrder(automovel1, automovel2);
            automoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_automovel_por_id()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var automovel = Builder<Automovel>.CreateNew()
                .With(c => c.GrupoDoAutomovel = grupoAutomoveis)
            .Persist();

            var automovelEncontrado = repositorioAutomovel.SelecionarPorId(automovel.Id);

            automovelEncontrado.Should().Be(automovel);
        }
    }
}
