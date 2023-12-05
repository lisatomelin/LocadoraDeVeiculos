using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        private Parceiro parceiro;

        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        public TelaParceiroForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Parceiro ObterParceiro()
        {
            parceiro.Nome = txtNome.Text;

            return parceiro;
        }

        public void ConfigurarParceiro(Parceiro parceiro)
        {
            this.parceiro = parceiro;

            txtNome.Text = parceiro.Nome;
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            this.parceiro = ObterParceiro();

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
