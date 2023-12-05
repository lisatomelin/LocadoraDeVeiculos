using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private ServicoCliente servicoCliente;
        private TabelaClienteControl tabelaCliente;

        public ControladorCliente
            (IRepositorioCliente repositorioCliente,
             ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaClienteForm tela = new TelaClienteForm();

            tela.onGravarRegistro += servicoCliente.Inserir;

            tela.ConfigurarCliente(new Cliente());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCliente.ObtemIdSelecionado();

            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(id);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            TelaClienteForm tela = new TelaClienteForm();

            tela.onGravarRegistro += servicoCliente.Editar;

            tela.ConfigurarCliente(clienteSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCliente.ObtemIdSelecionado();

            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(id);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o cliente?",
               "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCliente.Excluir(clienteSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarClientes();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarClientes();

            return tabelaCliente;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(clientes);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", clientes.Count, clientes.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
