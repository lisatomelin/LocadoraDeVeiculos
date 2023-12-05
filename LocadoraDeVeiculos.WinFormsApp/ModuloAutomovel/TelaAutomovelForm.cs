using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System.Collections;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel
{
    public partial class TelaAutomovelForm : Form
    {
        Automovel automovel;

        public event GravarRegistroDelegate<Automovel> onGravarRegistro;

        public TelaAutomovelForm(List<GrupoAutomoveis> grupoDeAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoDeAltomoveis(grupoDeAutomoveis);
            CarregarTipoCombustivel();
        }

        public Automovel ObterAutomovel()
        {
            decimal capacidadelitros;
            decimal kmAutomovel;

            automovel.Placa = txtPlaca.Text;
            automovel.Marca = txtMarca.Text;
            automovel.Cor = txtCor.Text;
            automovel.Modelo = txtModelo.Text;

            decimal.TryParse(txtKmAutomovel.Text, out kmAutomovel);
            automovel.KmAutomovel = kmAutomovel;

            decimal.TryParse(txtCapacidadeEmLitros.Text, out capacidadelitros);
            automovel.CapacidadeLitros = capacidadelitros;

            automovel.GrupoDoAutomovel = (GrupoAutomoveis)cbGrpAutomoveis.SelectedItem;
            automovel.TipoCombustivel = (TipoCombustivelEnum)cbTipoCombustivel.SelectedItem;

            byte[] foto = null;
            foto = ConverterImagemEmByte(foto);
            automovel.Foto = foto;


            return automovel;
        }

        public void ConfigurarAutomovel(Automovel automovel)
        {
            this.automovel = automovel;

            txtPlaca.Text = automovel.Placa;
            txtMarca.Text = automovel.Marca;
            txtCor.Text = automovel.Cor;
            txtModelo.Text = automovel.Modelo;
            txtCapacidadeEmLitros.Text = automovel.CapacidadeLitros.ToString();
            txtKmAutomovel.Text = automovel.KmAutomovel.ToString();
            cbGrpAutomoveis.SelectedItem = automovel.GrupoDoAutomovel;
            cbTipoCombustivel.SelectedItem = automovel.TipoCombustivel;

            Image foto = null;
            foto = ConverterByteArrayEmImagem(automovel, foto);
            picFotoCarro.Image = foto;
        }

        private Image? ConverterByteArrayEmImagem(Automovel automovel, Image? foto)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(automovel.Foto))
                {
                    foto = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter o byte array em imagem: {ex.Message}");
            }

            return foto;
        }

        private byte[]? ConverterImagemEmByte(byte[]? foto)
        {
            if (picFotoCarro.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picFotoCarro.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        foto = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao converter a imagem em byte array: {ex.Message}");
                }
            }

            return foto;
        }

        private void CarregarTipoCombustivel()
        {
            TipoCombustivelEnum[] tiposCombustiveis = Enum.GetValues<TipoCombustivelEnum>();

            ArrayList items = new ArrayList();

            foreach (Enum tipoCombustivel in tiposCombustiveis)
            {
                items.Add(tipoCombustivel);
            }

            cbTipoCombustivel.DataSource = items;
        }

        private void CarregarGrupoDeAltomoveis(List<GrupoAutomoveis> grupoDeAutomoveis)
        {
            cbGrpAutomoveis.Items.Clear();

            foreach (var item in grupoDeAutomoveis)
            {
                cbGrpAutomoveis.Items.Add(item);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Selecione uma imagem";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDaImagem = openFileDialog.FileName;

                Image imagem = Image.FromFile(caminhoDaImagem);

                picFotoCarro.Image = imagem;
            }
        }
    }
}
