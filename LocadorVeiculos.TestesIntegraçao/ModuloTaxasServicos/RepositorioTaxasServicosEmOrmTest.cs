using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TesteIntegracao.ModuloTaxasServicos
{
    [TestClass]
    public class RepositorioTaxasServicosEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_Taxas_ou_Servicos()
        {
            //arrange
            var taxa = Builder<TaxasServicos>.CreateNew().Build();

            //action
            repositorioTaxasServicos.Inserir(taxa);

            //Assert
            repositorioTaxasServicos.SelecionarPorId(taxa.Id).Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_Editar_Taxas_ou_Servicos()
        {
            var taxaId = Builder<TaxasServicos>.CreateNew().Persist().Id;

            var taxa = repositorioTaxasServicos.SelecionarPorId(taxaId);
            taxa.Nome = "taxa";

            repositorioTaxasServicos.Editar(taxa);

            repositorioTaxasServicos.SelecionarPorId(taxa.Id)
                .Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_excluir_Taxas_ou_Servicos()
        {
            var taxa = Builder<TaxasServicos>.CreateNew().Persist();
            repositorioTaxasServicos.Excluir(taxa);

            contextoPersistencia.GravarDados();

            repositorioTaxasServicos.SelecionarPorId(taxa.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_Taxas_ou_Servicos()
        {
            var taxa1 = Builder<TaxasServicos>.CreateNew().Persist();
            var taxa2 = Builder<TaxasServicos>.CreateNew().Persist();

            var taxas = repositorioTaxasServicos.SelecionarTodos();

            taxas.Should().ContainInOrder(taxa1, taxa2);
            taxas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_Taxas_ou_Servicos_por_nome()
        {
            var taxa = Builder<TaxasServicos>.CreateNew().Persist();

            var taxaEncontrada = repositorioTaxasServicos.SelecionarPorNome(taxa.Nome);

            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_selecionar_Taxas_ou_Servicos_por_id()
        {
            var taxa = Builder<TaxasServicos>.CreateNew().Persist();

            var taxaEncontrada = repositorioTaxasServicos.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().Be(taxa);
        }
    }
}
