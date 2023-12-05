using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoAutomoveis
{
    public class ControladorGrupoAutomoveis : ControladorBase
    {
        private TabelaGrupoAutomoveisControl tabelaGrupoAutomoveis;
        private ServicoGrupoAutomoveis servicoGrupoAutomoveis;
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        public ControladorGrupoAutomoveis(ServicoGrupoAutomoveis servicoGrupoAutomoveis,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
        {
            this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        }

        public override void Inserir()
        {
            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Inserir;

            tela.ConfigurarGrupoAutomoveis(new GrupoAutomoveis());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoAutomoveis();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomoveis grupoAutomoveisSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (grupoAutomoveisSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de automoveis primeiro",
                "Edição de Grupo de Automoveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Editar;

            tela.ConfigurarGrupoAutomoveis(grupoAutomoveisSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoAutomoveis();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomoveis grupoAutomoveisSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (grupoAutomoveisSelecionado == null)
            {
                MessageBox.Show("Selecione um Grupo de Automoveis primeiro",
                "Exclusão de Grupo de Automoveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Grupo de Automoveis?",
               "Exclusão de Grupo de Automoveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoGrupoAutomoveis.Excluir(grupoAutomoveisSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupo de Automoveis",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarGrupoAutomoveis();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoAutomoveis();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoAutomoveis == null)
                tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl();

            CarregarGrupoAutomoveis();

            return tabelaGrupoAutomoveis;
        }

        private void CarregarGrupoAutomoveis()
        {
            List<GrupoAutomoveis> grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

            tabelaGrupoAutomoveis.AtualizarRegistros(grupoAutomoveis);

            mensagemRodape = string.Format("Visualizando {0} Grupo de Automoveis", grupoAutomoveis.Count);

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
