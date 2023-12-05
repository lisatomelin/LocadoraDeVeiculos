using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_PlanoDeCobranca()
        {
            //arrange
            var cobranca = Builder<Cobranca>.CreateNew().Build();

            cobranca.GrupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();

            //action
            repositorioCobranca.Inserir(cobranca);

            contextoPersistencia.GravarDados();

            //assert
            repositorioCobranca.SelecionarPorId(cobranca.Id).Should().Be(cobranca);
        }
        [TestMethod]
        public void Deve_editar_cobranca()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var cobrancaId = Builder<Cobranca>.CreateNew()
                .With(c => c.GrupoAutomoveis = grupoAutomoveis)
                .Persist();

            cobrancaId.KmDisponivel = 50;

            //action
            repositorioCobranca.Editar(cobrancaId);

            contextoPersistencia.GravarDados();

            //assert
            repositorioCobranca.SelecionarPorId(cobrancaId.Id)
                .Should().Be(cobrancaId);
        }
        [TestMethod]
        public void Deve_excluir_cobranca()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var cobranca = Builder<Cobranca>.CreateNew()
                .With(c => c.GrupoAutomoveis = grupoAutomoveis)
                .Persist();

            //action
            repositorioCobranca.Excluir(cobranca);

            contextoPersistencia.GravarDados();

            //assert
            repositorioCobranca.SelecionarPorId(cobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_cobrancas()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var cobranca01 = Builder<Cobranca>.CreateNew()
                .With(c => c.GrupoAutomoveis = grupoAutomoveis)
                .Persist();

            var cobranca02 = Builder<Cobranca>.CreateNew()
                .With(c => c.GrupoAutomoveis = grupoAutomoveis)
                .Persist();

            //action
            var cobrancas = repositorioCobranca.SelecionarTodos();

            //assert
            cobrancas.Should().ContainInOrder(cobranca01, cobranca02);
            cobrancas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_cobranca_por_id()
        {
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var cobranca = Builder<Cobranca>.CreateNew()
                .With(c => c.GrupoAutomoveis = grupoAutomoveis)
                .Persist();

            var cobrancaEncontrada = repositorioCobranca.SelecionarPorId(cobranca.Id);

            cobrancaEncontrada.Should().Be(cobranca);
        }
    }
}

