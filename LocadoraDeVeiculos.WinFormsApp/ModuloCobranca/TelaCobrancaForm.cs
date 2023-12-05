using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System.Collections;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCobranca
{
    public partial class TelaCobrancaForm : Form
    {
        private Cobranca cobranca;
        public event GravarRegistroDelegate<Cobranca> onGravarRegistro;

        public TelaCobrancaForm(List<GrupoAutomoveis> grupoAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomoveis(grupoAutomoveis);
            CarregarEnum();

            cbTipoPlano.SelectedIndexChanged += TipoPlanoSelecionado;
        }

        public Cobranca ObterCobranca()
        {
            decimal precoporkm;
            decimal kmdisponivel;
            decimal precoDiaria;

            cobranca.GrupoAutomoveis = (GrupoAutomoveis)cbGrupoAutomoveis.SelectedItem;
            cobranca.TipoPlano = (TipoPlanoEnum)cbTipoPlano.SelectedValue;
            decimal.TryParse(txtPrecoDiaria.Text, out precoDiaria);
            cobranca.PrecoDiaria = precoDiaria;

            if (cobranca.TipoPlano == TipoPlanoEnum.PlanoDiario || cobranca.TipoPlano == TipoPlanoEnum.PlanoControlador)
            {
                Decimal.TryParse(txtPrecoExtrapolado.Text, out precoporkm);
                cobranca.PrecoPorKm = precoporkm;
            }

            if (cobranca.TipoPlano == TipoPlanoEnum.PlanoControlador)
            {
                Decimal.TryParse(txtKmDisponivel.Text, out kmdisponivel);
                cobranca.KmDisponivel = kmdisponivel;
            }

            return cobranca;
        }

        public void ConfigurarCobranca(Cobranca cobranca)
        {
            this.cobranca = cobranca;
            cbGrupoAutomoveis.SelectedItem = cobranca.GrupoAutomoveis;
            cbTipoPlano.SelectedValue = cobranca.TipoPlano;
            txtPrecoDiaria.Text = cobranca.PrecoDiaria.ToString();
            txtPrecoExtrapolado.Text = cobranca.PrecoPorKm.ToString();
            txtKmDisponivel.Text = cobranca.KmDisponivel.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.cobranca = ObterCobranca();

            Result resultado = onGravarRegistro(cobranca);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TipoPlanoSelecionado(object sender, EventArgs e)
        {
            AtualizarTextBoxes();
        }

        private void AtualizarTextBoxes()
        {
            TipoPlanoEnum tipoPlano = (TipoPlanoEnum)cbTipoPlano.SelectedValue;

            if (tipoPlano == TipoPlanoEnum.PlanoDiario)
            {
                txtKmDisponivel.Clear();

                txtPrecoExtrapolado.Enabled = true;
                txtKmDisponivel.Enabled = false;
            }
            else if (tipoPlano == TipoPlanoEnum.PlanoControlador)
            {
                txtPrecoExtrapolado.Enabled = true;
                txtKmDisponivel.Enabled = true;
            }
            else
            {
                txtPrecoExtrapolado.Clear();
                txtKmDisponivel.Clear();

                txtPrecoExtrapolado.Enabled = false;
                txtKmDisponivel.Enabled = false;
            }
        }


        private void CarregarEnum()
        {
            TipoPlanoEnum[] tipos = Enum.GetValues<TipoPlanoEnum>();

            ArrayList items = new ArrayList();

            foreach (Enum tipo in tipos)
            {
                var item = KeyValuePair.Create(tipo, tipo.GetDescription());
                items.Add(item);
            }

            cbTipoPlano.DataSource = items;
            cbTipoPlano.DisplayMember = "Value";
            cbTipoPlano.ValueMember = "Key";
        }

        private void CarregarGrupoAutomoveis(List<GrupoAutomoveis> grupoAutomoveis)
        {
            foreach (GrupoAutomoveis gp in grupoAutomoveis)
            {
                cbGrupoAutomoveis.Items.Add(gp);
            }
        }

        private void cbTipoPlano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
