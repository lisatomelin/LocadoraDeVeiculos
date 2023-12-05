using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TesteIntegracao.ModuloGrupoAutomoveis
{
    [TestClass]
    public class RepositorioGrupoAutomoveisEmOrmTeste : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();

            //action
            repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

            contextoPersistencia.GravarDados();

            //assert
            repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id).Should().Be(grupoAutomoveis);
        }

        [TestMethod]
        public void Deve_editar_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveisId = Builder<GrupoAutomoveis>.CreateNew().Persist().Id;

            var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);
            grupoAutomoveis.Nome = "História";

            //action
            repositorioGrupoAutomoveis.Editar(grupoAutomoveis);

            contextoPersistencia.GravarDados();

            //assert
            repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id)
                .Should().Be(grupoAutomoveis);
        }

        [TestMethod]
        public void Deve_excluir_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

            contextoPersistencia.GravarDados();

            //assert
            repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_grupoAutomoveis()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomoveis>.CreateNew().Persist();
            var grupo02 = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

            //assert
            grupoAutomoveis.Should().ContainInOrder(grupo01, grupo02);
            grupoAutomoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_com_automoveis()
        {
            //arrange
            var grupoAutomoveis01 = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var fordK = Builder<Automovel>.CreateNew().With(x => x.GrupoDoAutomovel = grupoAutomoveis01).Persist();
            var camaro = Builder<Automovel>.CreateNew().With(x => x.GrupoDoAutomovel = grupoAutomoveis01).Persist();

            //action
            var listGrupoAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos(incluirAutomoveis: true);

            //assert
            listGrupoAutomoveis[0].listaDeAutomoveis.Should().ContainInOrder(fordK, camaro);
            listGrupoAutomoveis[0].listaDeAutomoveis.Count.Should().Be(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_com_cobrancas()
        {
            //arrange
            var grupoAutomoveis01 = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var cobranca01 = Builder<Cobranca>.CreateNew().With(x => x.GrupoAutomoveis = grupoAutomoveis01).Persist();
            var cobranca02 = Builder<Cobranca>.CreateNew().With(x => x.GrupoAutomoveis = grupoAutomoveis01).Persist();

            //action
            var listGrupoAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos(incluirAutomoveis: false, incluirCobrancas: true);

            //assert
            listGrupoAutomoveis[0].listaDeCobrancas.Should().ContainInOrder(cobranca01, cobranca02);
            listGrupoAutomoveis[0].listaDeCobrancas.Count.Should().Be(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_nome()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupoAutomoveisEncontrado = repositorioGrupoAutomoveis.SelecionarPorNome(grupo01.Nome);

            //assert
            grupoAutomoveisEncontrado.Should().Be(grupo01);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_id()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupoAutomoveisEncontrado = repositorioGrupoAutomoveis.SelecionarPorId(grupo01.Id);

            //assert            
            grupoAutomoveisEncontrado.Should().Be(grupo01);
        }
    }
}

