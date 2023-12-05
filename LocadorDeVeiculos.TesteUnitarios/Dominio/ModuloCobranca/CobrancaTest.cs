using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloCobranca
{
    [TestClass]
    public class CobrancaTest
    {
        GrupoAutomoveis grupoAutomoveis;

        [TestInitialize]
        public void Initialize()
        {
            grupoAutomoveis = new GrupoAutomoveis("GrupoA");
        }

        [TestMethod]
        public void Deve_permitir_criar_cobranca_sem_km_disponivel()
        {
            // Arrange
            decimal precoDiaria = 150;
            decimal precoPorKm = 0;
            TipoPlanoEnum tipoPlano = TipoPlanoEnum.PlanoDiario;

            // Act
            Cobranca cobranca = new Cobranca(grupoAutomoveis, tipoPlano, precoDiaria, precoPorKm);

            // Assert
            cobranca.GrupoAutomoveis.Should().Be(grupoAutomoveis);
            cobranca.TipoPlano.Should().Be(tipoPlano);
            cobranca.PrecoDiaria.Should().Be(precoDiaria);
            cobranca.PrecoPorKm.Should().Be(precoPorKm);
            cobranca.KmDisponivel.Should().BeNull();
        }

        [TestMethod]
        public void Deve_permitir_criar_cobranca_com_km_disponivel()
        {
            // Arrange
            decimal precoDiaria = 100;
            decimal precoPorKm = 5;
            decimal kmDisponivel = 1000;
            TipoPlanoEnum tipoPlano = TipoPlanoEnum.PlanoControlador;

            // Act
            Cobranca cobranca = new Cobranca(grupoAutomoveis, tipoPlano, precoDiaria, precoPorKm, kmDisponivel);

            // Assert
            cobranca.GrupoAutomoveis.Should().Be(grupoAutomoveis);
            cobranca.TipoPlano.Should().Be(tipoPlano);
            cobranca.PrecoDiaria.Should().Be(precoDiaria);
            cobranca.PrecoPorKm.Should().Be(precoPorKm);
            cobranca.KmDisponivel.Should().Be(kmDisponivel);
        }

        [TestMethod]
        public void Deve_atualizar_cobranca_corretamente()
        {
            // Arrange
            decimal precoDiariaOriginal = 120;
            decimal precoPorKmOriginal = 3;
            decimal kmDisponivelOriginal = 800;
            TipoPlanoEnum tipoPlanoOriginal = TipoPlanoEnum.PlanoControlador;
            Cobranca cobranca = new Cobranca(grupoAutomoveis, tipoPlanoOriginal, precoDiariaOriginal, precoPorKmOriginal, kmDisponivelOriginal);

            decimal precoDiariaAtualizado = 130;
            decimal precoPorKmAtualizado = 4;
            decimal kmDisponivelAtualizado = 900;
            TipoPlanoEnum tipoPlanoAtualizado = TipoPlanoEnum.PlanoControlador;
            Cobranca cobrancaAtualizada = new Cobranca(grupoAutomoveis, tipoPlanoAtualizado, precoDiariaAtualizado, precoPorKmAtualizado, kmDisponivelAtualizado);

            // Act
            cobranca.Atualizar(cobrancaAtualizada);

            // Assert
            cobranca.GrupoAutomoveis.Should().Be(grupoAutomoveis);
            cobranca.TipoPlano.Should().Be(tipoPlanoAtualizado);
            cobranca.PrecoDiaria.Should().Be(precoDiariaAtualizado);
            cobranca.PrecoPorKm.Should().Be(precoPorKmAtualizado);
            cobranca.KmDisponivel.Should().Be(kmDisponivelAtualizado);
        }
    }
}
