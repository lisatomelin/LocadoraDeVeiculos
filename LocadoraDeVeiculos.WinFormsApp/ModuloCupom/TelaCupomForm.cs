using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCupom
{
    public partial class TelaCupomForm : Form
    {
        private Cupom cupom;
        public event GravarRegistroDelegate<Cupom> onGravarRegistro;

        public TelaCupomForm(List<Parceiro> parceiros)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            CarregarParceiros(parceiros);
        }

        public Cupom ObterCupom()
        {
            int valor;

            cupom.Nome = txtNome.Text;

            int.TryParse(txtValor.Text, out valor);
            cupom.Valor = valor;

            cupom.DataValidade = dateValidade.Value;
            cupom.Parceiro = (Parceiro)cbParceiro.SelectedItem;

            return cupom;
        }

        public void ConfigurarCupom(Cupom cupom)
        {
            this.cupom = cupom;
            txtNome.Text = cupom.Nome;
            txtValor.Text = cupom.Valor.ToString();
            cbParceiro.SelectedItem = cupom.Parceiro;
            dateValidade.MinDate = cupom.DataValidade;
        }

        private void CarregarParceiros(List<Parceiro> parceiros)
        {
            foreach (Parceiro parceiro in parceiros)
            {
                cbParceiro.Items.Add(parceiro);
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            this.cupom = ObterCupom();

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
