using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Dominio.ModuloGrupoAutomoveis
{
    [TestClass]
    public class GrupoAutomoveisTeste
    {
        GrupoAutomoveis grupoAutomoveis;
        Automovel automovel1;
        Cobranca cobranca01;

        public GrupoAutomoveisTeste()
        {
            grupoAutomoveis = new GrupoAutomoveis("Grupo01");
            automovel1 = new Automovel(1000, "Ford", "AAA-3333", "Preto", "FordK", TipoCombustivelEnum.Gasolina, 50, 2010);
            cobranca01 = new Cobranca(grupoAutomoveis, TipoPlanoEnum.PlanoDiario, 20, 10);
        }

        [TestMethod]
        public void Teste_Permitir_Inserir_Automoveis()
        {
            // Arrange
            var automovel2 = new Automovel(1000, "Ford", "BBB-4333", "Verde", "FordK", TipoCombustivelEnum.Gasolina, 50, 2010);
            var automovel3 = new Automovel(1000, "Ford", "CCC-5333", "Branco", "FordK", TipoCombustivelEnum.Gasolina, 50, 2010);

            // Act
            grupoAutomoveis.listaDeAutomoveis.Add(automovel1);
            grupoAutomoveis.listaDeAutomoveis.Add(automovel2);
            grupoAutomoveis.listaDeAutomoveis.Add(automovel3);

            // Assert
            grupoAutomoveis.listaDeAutomoveis.Count.Should().Be(3);

            //Assert.AreEqual(3, grupoAutomoveis.listaDeAutomoveis.Count);
            //CollectionAssert.Contains(grupoAutomoveis.listaDeAutomoveis, automovel1);
            //CollectionAssert.Contains(grupoAutomoveis.listaDeAutomoveis, automovel2);
            //CollectionAssert.Contains(grupoAutomoveis.listaDeAutomoveis, automovel3);
        }

        [TestMethod]
        public void Teste_Permitir_Inserir_Cobrancas()
        {
            // Arrange
            var cobranca02 = new Cobranca(grupoAutomoveis, TipoPlanoEnum.PlanoDiario, 30, 20);
            var cobranca03 = new Cobranca(grupoAutomoveis, TipoPlanoEnum.PlanoDiario, 40, 30);

            // Act
            grupoAutomoveis.listaDeCobrancas.Add(cobranca01);
            grupoAutomoveis.listaDeCobrancas.Add(cobranca02);
            grupoAutomoveis.listaDeCobrancas.Add(cobranca03);

            // Assert
            grupoAutomoveis.listaDeCobrancas.Count.Should().Be(3);
        }

        [TestMethod]
        public void ListaCobrancas_Deve_ser_diferente_de_null()
        {
            grupoAutomoveis.listaDeCobrancas.Should().NotBeNull();
        }

        [TestMethod]
        public void ListaAutomoveis_Deve_ser_diferente_de_null()
        {
            grupoAutomoveis.listaDeAutomoveis.Should().NotBeNull();
        }

        [TestMethod]
        public void Nao_deve_adicionar_automoveis_iguais_na_ListaDeAutomoveis()
        {
            //action
            grupoAutomoveis.AdicionarAutomovel(automovel1);
            grupoAutomoveis.AdicionarAutomovel(automovel1);

            //assert
            grupoAutomoveis.listaDeAutomoveis.Should().HaveCount(1);
        }

        [TestMethod]
        public void Nao_deve_adicionar_Cobrancas_iguais_na_ListaDeCobrancas()
        {
            //action
            grupoAutomoveis.AdicionarCobranca(cobranca01);
            grupoAutomoveis.AdicionarCobranca(cobranca01);

            //assert
            grupoAutomoveis.listaDeCobrancas.Should().HaveCount(1);
        }
    }
}
