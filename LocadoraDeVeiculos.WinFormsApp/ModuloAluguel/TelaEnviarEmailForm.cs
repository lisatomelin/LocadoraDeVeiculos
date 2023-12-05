using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System.Net;
using System.Net.Mail;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    public partial class TelaEnviarEmailForm : Form
    {

        private string caminhoDoArquivoPDF = "";

        public TelaEnviarEmailForm(/*List<Cliente> clientes*/)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            //CarregarClientes(clientes);
            txtSenhaEmail.PasswordChar = '*';
            txtSenhaEmail.MaxLength = 20;
        }

        //private void CarregarClientes(List<Cliente> clientes)
        //{
        //    foreach (Cliente cliente in clientes)
        //    {
        //        cbCliente.Items.Add(cliente);
        //    }
        //}

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                mm.From = new MailAddress(txtEmailFuncionario.Text);
                mm.To.Add(txtEmailCliente.Text);
                mm.Subject = txtAssunto.Text;
                mm.Body = txtMensagem.Text;

                //if (!string.IsNullOrEmpty(txtMostrarPdf.Text))
                //{
                //    Attachment anexo = new Attachment(txtMostrarPdf.Text);
                //    mm.Attachments.Add(anexo);
                //}


                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential(txtEmailFuncionario.Text, txtSenhaEmail.Text);
                sc.EnableSsl = true;
                sc.Send(mm);
                MessageBox.Show("Email Enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSelecionarPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoDoArquivoPDF = openFileDialog.FileName;

                txtMostrarPdf.Text = caminhoDoArquivoPDF;
            }
        }
    }
}
