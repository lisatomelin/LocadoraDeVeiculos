using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoAutomoveis
{
    public partial class TelaGrupoAutomoveisForm : Form
    {
        private GrupoAutomoveis grupoAutomoveis;
        public event GravarRegistroDelegate<GrupoAutomoveis> onGravarRegistro;

        public TelaGrupoAutomoveisForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public GrupoAutomoveis ObterGrupoAutomoveis()
        {
            grupoAutomoveis.Nome = txtNome.Text;

            return grupoAutomoveis;
        }

        public void ConfigurarGrupoAutomoveis(GrupoAutomoveis grupoAutomoveis)
        {
            this.grupoAutomoveis = grupoAutomoveis;

            txtNome.Text = grupoAutomoveis.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.grupoAutomoveis = ObterGrupoAutomoveis();

            Result resultado = onGravarRegistro(grupoAutomoveis);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
