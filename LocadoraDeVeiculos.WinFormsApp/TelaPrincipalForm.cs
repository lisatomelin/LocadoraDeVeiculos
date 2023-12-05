using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado.IoC;
using LocadoraDeVeiculos.WinFormsApp.ModuloAluguel;
using LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinFormsApp.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.ModuloCobranca;
using LocadoraDeVeiculos.WinFormsApp.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.ModuloCupom;
using LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.ModuloParceiro;
using LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos;

namespace LocadoraDeVeiculos.WinFormsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private IoC IoC;

        public TelaPrincipalForm()
        {

            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            lblTipoCadastro.Text = string.Empty;

            IoC = new IoC_ComInjecaoDespendecia();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }


        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void ConfigurarBotoes(ConfiguracaoToolBoxBase configuracao)
        {
            btnAdicionar.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnPrecos.Enabled = configuracao.PrecoHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnPdf.Enabled = configuracao.PdfHabilitado;
            btnDevolucao.Enabled = configuracao.DevolucaoHabilitado;
            btnEmail.Enabled = configuracao.EmailHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolBoxBase configuracao)
        {
            btnAdicionar.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnPrecos.ToolTipText = configuracao.TooltipPrecos;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnPdf.ToolTipText = configuracao.TooltipPdf;
            btnDevolucao.ToolTipText = configuracao.TooltipDevolucao;
            btnEmail.ToolTipText = configuracao.TooltipEmail;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();

            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolBoxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolBox.Enabled = true;

                lblTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnPrecos_Click(object sender, EventArgs e)
        {
            controlador.Precos();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorFuncionario>());
        }

        private void taxasEServiçosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorTaxasServicos>());
        }

        private void cupomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCupom>());
        }

        private void parceiroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorParceiro>());
        }

        private void aluguelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorAluguel>());
        }

        private void grupoDeAutomóveisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorGrupoAutomoveis>());
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCobranca>());
        }

        private void automóvelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorAutomovel>());
        }

        private void condutorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCondutor>());
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCliente>());
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            controlador.Pdf();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            controlador.Email();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            controlador.Devolucao();
        }
    }
}
