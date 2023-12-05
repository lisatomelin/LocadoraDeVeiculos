﻿using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TesteIntegracao.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_funcionario()
        {
            var Funcionario = Builder<Funcionario>.CreateNew().Build();

            repositorioFuncionario.Inserir(Funcionario);

            contextoPersistencia.GravarDados();

            repositorioFuncionario.SelecionarPorId(Funcionario.Id).Should().Be(Funcionario);
        }

        [TestMethod]
        public void Deve_Editar_funcionario()
        {
            var funcionarioId = Builder<Funcionario>.CreateNew().Persist().Id;

            var funcionario = repositorioFuncionario.SelecionarPorId(funcionarioId);
            funcionario.Nome = "Cleiton";

            repositorioFuncionario.Editar(funcionario);

            contextoPersistencia.GravarDados();

            repositorioFuncionario.SelecionarPorId(funcionario.Id)
                .Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.Excluir(funcionario);

            contextoPersistencia.GravarDados();

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_funcionarios()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = Builder<Funcionario>.CreateNew().Persist();

            var funcionarios = repositorioFuncionario.SelecionarTodos();

            funcionarios.Should().ContainInOrder(funcionario1, funcionario2);
            funcionarios.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_funcionario_por_nome()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_selecionar_funcionario_por_id()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            //assert            
            funcionarioEncontrado.Should().Be(funcionario);
        }
    }
}
