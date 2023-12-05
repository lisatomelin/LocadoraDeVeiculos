using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;
using System.Drawing.Drawing2D;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioAluguelEmOrmTest : TestesIntegracaoBase
    {

        [TestMethod]
        public void Deve_inserir_Aluguel()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Build();
            var cliente = Builder<Cliente>.CreateNew().Build();
            var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();
            var cupom = Builder<Cupom>.CreateNew().Build();
            cupom.Parceiro = parceiro;
            var automovel = Builder<Automovel>.CreateNew().Build();
            automovel.GrupoDoAutomovel = grupoAutomoveis;
            var taxasServicos = Builder<TaxasServicos>.CreateNew().Build();
            var funcionario = Builder<Funcionario>.CreateNew().Build();
            var condutor = Builder<Condutor>.CreateNew().Build();
            condutor.Cliente = cliente;
            var cobranca = Builder<Cobranca>.CreateNew().Build();
            cobranca.GrupoAutomoveis = grupoAutomoveis;
            var aluguel = Builder<Aluguel>.CreateNew().Build();
            aluguel.Condutor = condutor;
            aluguel.Cobranca = cobranca;
            aluguel.Cliente = cliente;
            aluguel.Automovel = automovel;
            aluguel.ListaTaxasSelecionadas.Add(taxasServicos);
            aluguel.GrupoAutomoveis = grupoAutomoveis;
            aluguel.Funcionario = funcionario;
            aluguel.Cupom = cupom;


            //action
            repositorioAluguel.Inserir(aluguel);

            contextoPersistencia.GravarDados();

            //assert
            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().Be(aluguel);
        }

        //[TestMethod]
        //public void Deve_editar_aluguel()
        //{
        //    //arrange
        //    var parceiro = Builder<Parceiro>.CreateNew().Build();
        //    var cliente = Builder<Cliente>.CreateNew().Build();
        //    var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();
        //    var cupom = Builder<Cupom>.CreateNew()
        //        .With(a => a.Parceiro = parceiro)
        //        .Build(); ;
        //    var automovel = Builder<Automovel>.CreateNew()
        //        .With(a => a.GrupoDoAutomovel = grupoAutomoveis)
        //        .Build();
        //    var taxasServicos = Builder<TaxasServicos>.CreateNew().Build();
        //    var funcionario = Builder<Funcionario>.CreateNew().Build();
        //    var condutor = Builder<Condutor>.CreateNew()
        //        .With(c => c.Cliente = cliente)
        //        .Build();
        //    var cobranca = Builder<Cobranca>.CreateNew()
        //        .With(c => c.GrupoAutomoveis = grupoAutomoveis)
        //        .Build();
        //    var aluguel = Builder<Aluguel>.CreateNew()
        //        .With(a => a.Condutor = condutor)
        //        .With(a => a.Cobranca = cobranca)
        //        .With(a => a.Cliente = cliente)
        //        .With(a => a.Automovel = automovel)
        //        .With(a => a.GrupoAutomoveis = grupoAutomoveis)
        //        .With(a => a.Funcionario = funcionario)
        //        .With(a => a.Cupom = cupom)
        //        .Build();

        //    aluguel.DataLocacao = DateTime.Now;

        //    //action
        //    repositorioAluguel.Editar(aluguel);

        //    contextoPersistencia.GravarDados();

        //    //assert
        //    repositorioAluguel.SelecionarPorId(aluguel.Id)
        //        .Should().Be(aluguel);
        //}

        //[TestMethod]
        //public void Deve_excluir_aluguel()
        //{
        //    var parceiro = Builder<Parceiro>.CreateNew().Build();
        //    var cliente = Builder<Cliente>.CreateNew().Build();
        //    var grupoAutomoveis = Builder<GrupoAutomoveis>.CreateNew().Build();
        //    var cupom = Builder<Cupom>.CreateNew()
        //        .With(a => a.Parceiro = parceiro)
        //        .Build(); ;
        //    var automovel = Builder<Automovel>.CreateNew()
        //        .With(a => a.GrupoDoAutomovel = grupoAutomoveis)
        //        .Build();
        //    var taxasServicos = Builder<TaxasServicos>.CreateNew().Build();
        //    var funcionario = Builder<Funcionario>.CreateNew().Build();
        //    var condutor = Builder<Condutor>.CreateNew()
        //        .With(c => c.Cliente = cliente)
        //        .Build();
        //    var cobranca = Builder<Cobranca>.CreateNew()
        //        .With(c => c.GrupoAutomoveis = grupoAutomoveis)
        //        .Build();
        //    var aluguel = Builder<Aluguel>.CreateNew()
        //        .With(a => a.Condutor = condutor)
        //        .With(a => a.Cobranca = cobranca)
        //        .With(a => a.Cliente = cliente)
        //        .With(a => a.Automovel = automovel)
        //        .With(a => a.GrupoAutomoveis = grupoAutomoveis)
        //        .With(a => a.Funcionario = funcionario)
        //        .With(a => a.Cupom = cupom)
        //        .With(a => a.ListaTaxasSelecionadas)
        //        .Build();

        //    //action
        //    repositorioAluguel.Excluir(aluguel);
        //    contextoPersistencia.GravarDados();

        //    //assert
        //    repositorioAluguel.SelecionarPorId(aluguel.Id).Should().BeNull();
        //}

        //[TestMethod]
        //public void Deve_selecionar_aluguel_por_id()
        //{
        //    //arrange
        //    var aluguel02 = Builder<Aluguel>.CreateNew().Persist();

        //    //action
        //    var aluguelEncontrado = repositorioAluguel.SelecionarPorId(aluguel02.Id);

        //    //assert            
        //    aluguelEncontrado.Should().Be(aluguel02);
        //}
    }
}

