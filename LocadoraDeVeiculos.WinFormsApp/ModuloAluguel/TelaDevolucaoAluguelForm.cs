using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    public partial class TelaDevolucaoAluguelForm : Form
    {
        Aluguel aluguel;

        bool telaCarregada = false;

        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

        List<TaxasServicos> taxasServicos;

        public TelaDevolucaoAluguelForm(List<Funcionario> funcionarios, List<Cliente> clientes, List<GrupoAutomoveis> grupoAutomoveis, List<Cobranca> planoCobrancas, List<Condutor> condutores, List<Automovel> automoveis, List<Cupom> cupons, List<TaxasServicos> taxasServicos)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            //CarregarFuncionario(funcionarios);
            //CarregarCliente(clientes);
            //CarregarGrupoAutomoveis(grupoAutomoveis);
            //CarregarPlanoCobranca(planoCobrancas);
            //CarregarCondutor(condutores);
            //CarregarAutomoveis(automoveis);
            //CarregarCupons(cupons);

            CarregarEnumTanque();
            this.taxasServicos = taxasServicos;
        }

        public Aluguel ObterAluguel()
        {
            decimal kmAutomovel;

            //aluguel.Funcionario = (Funcionario)cbFuncionario.SelectedItem;
            //aluguel.Cliente = (Cliente)cbCliente.SelectedItem;
            //aluguel.GrupoAutomoveis = (GrupoAutomoveis)cbGrupoAutomoveis.SelectedItem;
            //aluguel.Cobranca = (Cobranca)cbPlanoDeCobranca.SelectedItem;
            //aluguel.DataLocacao = dtLocacao.Value.Date;
            //aluguel.DevolucaoPrevista = dtDevolucaoPrevista.Value.Date;
            //aluguel.Condutor = (Condutor)cbCondutor.SelectedItem;
            //aluguel.Automovel = (Automovel)cbAutomovel.SelectedItem;

            decimal valor = 0;

            if ((CombustivelNoTanqueEnum)cbNivelDoTanque.SelectedValue == CombustivelNoTanqueEnum.Vazio)
            {
                valor = 0;
            }
            if ((CombustivelNoTanqueEnum)cbNivelDoTanque.SelectedValue == CombustivelNoTanqueEnum.UmQuarto)
            {
                valor = 25;
            }
            if ((CombustivelNoTanqueEnum)cbNivelDoTanque.SelectedValue == CombustivelNoTanqueEnum.Meio)
            {
                valor = 50;
            }
            if ((CombustivelNoTanqueEnum)cbNivelDoTanque.SelectedValue == CombustivelNoTanqueEnum.TresQuartos)
            {
                valor = 75;
            }
            if ((CombustivelNoTanqueEnum)cbNivelDoTanque.SelectedValue == CombustivelNoTanqueEnum.Cheio)
            {
                valor = 100;
            }

            aluguel.CombustivelNoTanque = (CombustivelNoTanqueEnum)valor;
            aluguel.KmPercorrida = Convert.ToDecimal(txtKmPercorrido.Text);
            aluguel.DataDevolucao = dtDataDevolucao.Value.Date;


            decimal.TryParse(txtKmAutomovel.Text, out kmAutomovel);
            aluguel.KmAutomovel = kmAutomovel;

            if (cbCupom != null)
            {
                aluguel.Cupom = (Cupom)cbCupom.SelectedItem;
            }

            aluguel.ListaTaxasSelecionadas = ObterTaxasMarcadas();

            return aluguel;
        }

        public void ConfigurarAluguel(Aluguel aluguel)
        {
            this.aluguel = aluguel;

            cbFuncionario.SelectedItem = aluguel.Funcionario;
            cbCliente.SelectedItem = aluguel.Cliente;
            cbGrupoAutomoveis.SelectedItem = aluguel.GrupoAutomoveis;
            cbPlanoDeCobranca.SelectedItem = aluguel.Cobranca;
            cbCondutor.SelectedItem = aluguel.Condutor;
            cbAutomovel.SelectedItem = aluguel.Automovel;
            dtLocacao.MinDate = aluguel.DataLocacao;
            dtDevolucaoPrevista.MinDate = aluguel.DevolucaoPrevista;
            txtKmAutomovel.Text = aluguel.KmAutomovel.ToString();

            cbNivelDoTanque.SelectedValue = aluguel.CombustivelNoTanque;
            txtKmPercorrido.Text = aluguel.KmPercorrida.ToString();
            dtDataDevolucao.MinDate = aluguel.DataDevolucao;

            if (aluguel.Cupom != null)
            {
                cbCupom.SelectedItem = this.aluguel.Cupom;
            }

            CarregarTaxasServicos();

            int i = 0;

            for (int j = 0; j < chListTaxas.Items.Count; j++)
            {
                TaxasServicos taxa = (TaxasServicos)chListTaxas.Items[j];

                if (aluguel.ListaTaxasSelecionadas.Contains(taxa))
                    chListTaxas.SetItemChecked(i, true);

                i++;
            }

            telaCarregada = true;

            txtValorTotal.Text = aluguel.ValorTotalPrevisto.ToString();
        }

        public List<TaxasServicos> ObterTaxasMarcadas()
        {
            return chListTaxas.CheckedItems.Cast<TaxasServicos>().ToList();
        }

        private void CarregarEnumTanque()
        {
            CombustivelNoTanqueEnum[] tipos = Enum.GetValues<CombustivelNoTanqueEnum>();

            ArrayList items = new ArrayList();

            foreach (Enum tipo in tipos)
            {
                var item = KeyValuePair.Create(tipo, tipo.GetDescription());
                items.Add(item);
            }

            cbNivelDoTanque.DataSource = items;
            cbNivelDoTanque.DisplayMember = "Value";
            cbNivelDoTanque.ValueMember = "Key";
        }

        private void CarregarTaxasServicos()
        {
            chListTaxas.Items.Clear();

            foreach (var taxa in taxasServicos)
            {
                chListTaxas.Items.Add(taxa);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.aluguel = ObterAluguel();

            Result resultado = onGravarRegistro(aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
