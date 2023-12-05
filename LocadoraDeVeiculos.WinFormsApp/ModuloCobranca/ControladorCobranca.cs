using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCobranca
{
    public class ControladorCobranca : ControladorBase
    {
        private TabelaCupomControl tabelaCobranca;
        private ServicoCobranca servicoCobranca;
        private IRepositorioCobranca repositorioCobranca;
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        public ControladorCobranca(ServicoCobranca servicoCobranca, IRepositorioCobranca repositorioCobranca, IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
        {
            this.servicoCobranca = servicoCobranca;
            this.repositorioCobranca = repositorioCobranca;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        }

        public override void Inserir()
        {
            TelaCobrancaForm tela = new TelaCobrancaForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoCobranca.Inserir;

            tela.ConfigurarCobranca(new Cobranca());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCobrancas();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCobranca.ObtemIdSelecionado();

            Cobranca cobrancaSelecionada = repositorioCobranca.SelecionarPorId(id);

            if (cobrancaSelecionada == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Edição de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCobrancaForm tela = new TelaCobrancaForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoCobranca.Editar;

            tela.ConfigurarCobranca(cobrancaSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCobrancas();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCobranca.ObtemIdSelecionado();

            Cobranca cobrancaSelecionada = repositorioCobranca.SelecionarPorId(id);

            if (cobrancaSelecionada == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Exclusão de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Plano de Cobrança?",
               "Exclusão de Planos de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCobranca.Excluir(cobrancaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Planos de Cobrança",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCobrancas();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCobranca == null)
                tabelaCobranca = new TabelaCupomControl();

            CarregarCobrancas();

            return tabelaCobranca;
        }

        private void CarregarCobrancas()
        {
            List<Cobranca> cobrancas = repositorioCobranca.SelecionarTodos();

            tabelaCobranca.AtualizarRegistros(cobrancas);

            mensagemRodape = string.Format("Visualizando {0} Plano{1} de cobrança", cobrancas.Count, cobrancas.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
