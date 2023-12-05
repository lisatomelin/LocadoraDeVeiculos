using LocadoraDeVeiculos.Dominio.ModuloPrecos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPrecos
{
    public partial class TelaPrecosForm : Form
    {
        private Precos precos;
        public event GravarRegistroDelegate<Precos> onGravarRegistro;

        public TelaPrecosForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.precos = new Precos();
        }

        public Precos ObterPrecos()
        {
            Precos novoPrecos = new Precos();
            novoPrecos.Gasolina = Convert.ToDecimal(txtGasolina.Text);
            novoPrecos.Gas = Convert.ToDecimal(txtGas.Text);
            novoPrecos.Diesel = Convert.ToDecimal(txtDiesel.Text);
            novoPrecos.Alcool = Convert.ToDecimal(txtAlcool.Text);

            return novoPrecos;
        }

        public void ConfigurarPrecos(Precos precos)
        {
            this.precos = precos;
            txtGasolina.Text = precos.Gasolina.ToString();
            txtGas.Text = precos.Gas.ToString();
            txtDiesel.Text = precos.Diesel.ToString();
            txtAlcool.Text = precos.Alcool.ToString();
        }
    }
}
