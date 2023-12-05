using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public partial class TelaCondutorForm : Form
    {
        private Condutor condutor;
        public event GravarRegistroDelegate<Condutor> onGravarRegistro;

        public TelaCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarClientes(clientes);
        }

        public Condutor ObterCondutor()
        {
            condutor.Cliente = (Cliente)cbCliente.SelectedItem;
            condutor.Cnh = txtCnh.Text;
            condutor.Cpf = txtCpf.Text;
            condutor.Email = txtEmail.Text;
            condutor.Nome = txtNome.Text;
            condutor.Telefone = txtTelefone.Text;
            condutor.ClienteCondutor = chEhCondutor.Checked;
            condutor.Validade = dateValidade.Value;

            return condutor;
        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            this.condutor = condutor;
            txtEmail.Text = condutor.Email;
            txtCpf.Text = condutor.Cpf;
            txtCnh.Text = condutor.Cnh;
            txtTelefone.Text = condutor.Telefone;
            txtNome.Text = condutor.Nome;
            cbCliente.SelectedItem = condutor.Cliente;
            chEhCondutor.Checked = condutor.ClienteCondutor;
            dateValidade.MinDate = condutor.Validade;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.condutor = ObterCondutor();

            Result resultado = onGravarRegistro(condutor);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                cbCliente.Items.Add(cliente);
            }
        }

        private void chEhCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (condutor == null)
                condutor = new Condutor();

            if (chEhCondutor.Checked)
            {
                Cliente cliente = (Cliente)cbCliente.SelectedItem;

                txtNome.Text = cliente.Nome;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
                txtCpf.Text = cliente.Cpf;
            }
            else
            {
                txtNome.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtCpf.Clear();
            }
        }
        private void cbCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            chEhCondutor.Enabled = true;
        }
    }
}
