using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.TesteIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TesteIntegracao.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_cliente()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();
            repositorioCliente.Inserir(cliente);

            contextoPersistencia.GravarDados();

            repositorioCliente.SelecionarPorId(cliente.Id).Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_Editar_cliente()
        {
            var clienteId = Builder<Cliente>.CreateNew().Persist().Id;

            var cliente = repositorioCliente.SelecionarPorId(clienteId);
            cliente.Nome = "Cleiton";

            repositorioCliente.Editar(cliente);

            contextoPersistencia.GravarDados();

            repositorioCliente.SelecionarPorId(cliente.Id)
                .Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            repositorioCliente.Excluir(cliente);

            contextoPersistencia.GravarDados();

            repositorioCliente.SelecionarPorId(cliente.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_clientes()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = Builder<Cliente>.CreateNew().Persist();

            var clientes = repositorioCliente.SelecionarTodos();

            clientes.Should().ContainInOrder(cliente1, cliente2);
            clientes.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_nome()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var clienteEncontrado = repositorioCliente.SelecionarPorNome(cliente.Nome);

            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_id()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().Be(cliente);
        }
    }
}
