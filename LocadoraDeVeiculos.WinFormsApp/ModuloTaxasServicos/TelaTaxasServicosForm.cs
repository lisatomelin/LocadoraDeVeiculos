using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos
{
    public partial class TelaTaxasServicosForm : Form
    {
        private TaxasServicos taxasServicos;

        public event GravarRegistroDelegate<TaxasServicos> onGravarRegistro;

        public TelaTaxasServicosForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public TaxasServicos ObterTaxasServicos()
        {
            decimal preco;

            taxasServicos.Nome = txtNome.Text;

            decimal.TryParse(txtPreco.Text, out preco);
            taxasServicos.Preco = preco;

            taxasServicos.PrecoFixo = rdbPrecoFixo.Checked;

            taxasServicos.PrecoDiaria = rdbCobranca.Checked;

            return taxasServicos;
        }

        public void ConfigurarTaxasServicos(TaxasServicos taxasServicos)
        {
            this.taxasServicos = taxasServicos;

            txtNome.Text = taxasServicos.Nome;
            txtPreco.Text = taxasServicos.Preco.ToString();
            rdbPrecoFixo.Checked = taxasServicos.PrecoFixo;
            rdbCobranca.Checked = taxasServicos.PrecoDiaria;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.taxasServicos = ObterTaxasServicos();

            Result resultado = onGravarRegistro(taxasServicos);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
