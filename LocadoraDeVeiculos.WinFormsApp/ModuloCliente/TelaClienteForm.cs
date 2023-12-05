using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;
        public event GravarRegistroDelegate<Cliente> onGravarRegistro;

        public TelaClienteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Cliente ObterCliente()
        {
            int numerocasa;

            cliente.Nome = txtNome.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cnpj = txtCnpj.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Email = txtEmail.Text;
            cliente.Estado = txtEstado.Text;

            int.TryParse(txtNumero.Text, out numerocasa);
            cliente.NumeroCasa = numerocasa;

            cliente.Rua = txtRua.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Telefone = txtTelefone.Text;

            if (rdbFisica.Checked)
                cliente.TipoCliente = TipoClienteEnum.PessoaFisica;
            else if (rdbJuridica.Checked)
                cliente.TipoCliente = TipoClienteEnum.PessoaJuridica;

            return cliente;
        }

        public void ConfigurarCliente(Cliente cliente)
        {
            this.cliente = cliente;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            txtCnpj.Text = cliente.Cnpj;
            txtCpf.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            txtEstado.Text = cliente.Estado;
            txtNumero.Text = cliente.NumeroCasa.ToString();
            txtRua.Text = cliente.Rua;
            txtTelefone.Text = cliente.Telefone;
            txtNome.Text = cliente.Nome;

            if (cliente.TipoCliente == TipoClienteEnum.PessoaFisica)
                rdbFisica.Checked = true;
            else
                rdbJuridica.Checked = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.cliente = ObterCliente();

            Result resultado = onGravarRegistro(cliente);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void rdbFisica_CheckedChanged(object sender, EventArgs e)
        {
            txtCnpj.Clear();
            txtCnpj.Enabled = false;
            txtCpf.Enabled = true;
        }

        private void rdbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            txtCpf.Clear();
            txtCpf.Enabled = false;
            txtCnpj.Enabled = true;
        }
    }
}
